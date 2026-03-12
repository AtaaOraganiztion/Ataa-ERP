using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Entities;
using Domain.Models;
using Infrastructure.Converters;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Sector;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Common;

namespace Infrastructure.Database.Seeders;

public class SectorDataSeeder(ApplicationDbContext dbContext,
    ILogger<SectorDataSeeder> logger)
{
    private readonly string _seedingDataPath = Path.Combine(
        AppContext.BaseDirectory,
        "Database", "SeedingData");
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new UlidJsonConverter(), new JsonStringEnumConverter() }
    };
    public async Task SeedAsync(List<KeyValuePair<string, string>> permissions)
    {
        try
        {
            await SeedSectorAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding identity data");
            throw new Exception("An error occurred while seeding identity data", ex);
        }
    }
    
    private async Task SeedSectorAsync()
    {
        // Repair any sectors that were inserted with the default/empty Ulid
        await RepairDefaultSectorIdsAsync();

        if (await dbContext.Sectors.AnyAsync())
        {
            logger.LogInformation("Sectors already seeded");
            return;
        }

        // use lowercase filename (matches the file in the project)
        string sectorsFilePath = Path.Combine(_seedingDataPath, "sectors.json");
        if (!File.Exists(sectorsFilePath))
        {
            logger.LogWarning("Sectors.json file not found at {FilePath}", sectorsFilePath);
            return;
        }

        string sectorsJson = File.ReadAllText(sectorsFilePath);
        List<SectorData>? sectorsData = JsonSerializer.Deserialize<List<SectorData>>(sectorsJson, _jsonOptions);

        if (sectorsData == null || !sectorsData.Any())
        {
            logger.LogWarning("No Sectors data found in the JSON file");
            return;
        }

        // Load existing sector names to avoid duplicates
        var existingNames = new HashSet<string>(await dbContext.Sectors.Select(x => x.Name).ToListAsync(), StringComparer.OrdinalIgnoreCase);

        var toAdd = new List<Sector>();

        foreach (var s in sectorsData)
        {
            if (string.IsNullOrWhiteSpace(s.Name))
            {
                logger.LogWarning("Skipping sector with empty name in seed file");
                continue;
            }

            if (existingNames.Contains(s.Name))
            {
                logger.LogInformation("Sector already exists, skipping: {Name}", s.Name);
                continue;
            }

            // If the JSON didn't contain an Id, generate a new one so we don't insert all-zero ids
            var sectorId = s.Id ?? Ulid.NewUlid();

            var sector = new Sector
            {
                Id = sectorId,
                Name = s.Name.Trim(),
                Description = s.Description,
                ParentSectorId = null,
                ManagerUserId = null,
                Manager = null
            };

            toAdd.Add(sector);
            existingNames.Add(sector.Name);
        }

        if (toAdd.Count > 0)
        {
            await dbContext.Sectors.AddRangeAsync(toAdd);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Successfully seeded {Count} sectors", toAdd.Count);
        }
        else
        {
            logger.LogInformation("No new sectors to seed");
        }
    }
    private async Task RepairDefaultSectorIdsAsync()
    {
        var defaultId = default(Ulid);
        var badSectors = await dbContext.Sectors.Where(s => s.Id == defaultId).ToListAsync();
        if (!badSectors.Any())
            return;

        // For each sector with default id, ensure no dependent references exist before changing the PK.
        foreach (var s in badSectors)
        {
            bool hasChildren = await dbContext.Sectors.AnyAsync(x => x.ParentSectorId == s.Id);
            bool hasEmployees = await dbContext.Set<Domain.Models.Employee.Employee>().AnyAsync(e => e.SectorId == s.Id);
            if (hasChildren || hasEmployees)
            {
                logger.LogWarning("Cannot repair sector '{Name}' with default Id because dependent FK references exist. Manual fix required.", s.Name);
                continue;
            }

            var newId = Ulid.NewUlid();
            logger.LogInformation("Updating sector '{Name}' Id from default to {NewId}", s.Name, newId);
            s.Id = newId;
        }

        await dbContext.SaveChangesAsync();
    }
    private sealed class SectorData
    {
        public Ulid? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Ulid? ParentSectorId { get; set; }
        public Ulid? ManagerUserId { get; set; }
    }
}