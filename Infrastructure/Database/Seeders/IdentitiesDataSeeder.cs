using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Converters;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SharedKernel;
using Role = Domain.Entities.Role;

namespace Infrastructure.Database.Seeders;

public class IdentitiesDataSeeder(
    ApplicationDbContext dbContext,
    ILogger<IdentitiesDataSeeder> logger,
    UserManager<User> userManager)
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
            SeedRoles();
            await SeedUsersAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding identity data");
            throw new Exception("An error occurred while seeding identity data", ex);
        }
    }

    private void SeedRoles()
    {
        if (dbContext.Roles.Any())
        {
            logger.LogInformation("Roles already seeded");
            return;
        }

        string rolesFilePath = Path.Combine(_seedingDataPath, "Roles.json");
        if (!File.Exists(rolesFilePath))
        {
            logger.LogWarning("Roles.json file not found at {FilePath}", rolesFilePath);
            return;
        }

        string rolesJson = File.ReadAllText(rolesFilePath);
        List<Role>? roles = JsonSerializer.Deserialize<List<Role>>(rolesJson, _jsonOptions);

        if (roles == null || !roles.Any())
        {
            logger.LogWarning("No Roles data found in the JSON file");
            return;
        }

        dbContext.Roles.AddRange(roles);
        dbContext.SaveChanges();

        logger.LogInformation("Successfully seeded {Count} roles", roles.Count);
    }

    private async Task SeedUsersAsync()
    {
        if (dbContext.Users.Any())
        {
            logger.LogInformation("Users already seeded");
            return;
        }

        string usersFilePath = Path.Combine(_seedingDataPath, "Users.json");
        if (!File.Exists(usersFilePath))
        {
            logger.LogWarning("Users.json file not found at {FilePath}", usersFilePath);
            return;
        }

        string usersJson = File.ReadAllText(usersFilePath);

        // Clean JSON from possible BOM or line comments coming from other editors or manual edits on different machines
        usersJson = CleanJson(usersJson);

        List<UserData>? usersData;
        try
        {
            usersData = JsonSerializer.Deserialize<List<UserData>>(usersJson, _jsonOptions);
        }
        catch (JsonException jsonEx)
        {
            logger.LogError(jsonEx, "Failed to deserialize Users.json (first 1KB): {JsonPreview}",
                usersJson.Length > 1024 ? usersJson.Substring(0, 1024) : usersJson);
            throw;
        }

        if (usersData == null || !usersData.Any())
        {
            logger.LogWarning("No Users data found in the JSON file");
            return;
        }

        foreach (var u in usersData)
        {
            if (string.IsNullOrWhiteSpace(u.Email))
            {
                logger.LogError("Skipping user with missing email: {Name}", u.Name);
                continue;
            }

            var newUser = new User
            {
                Id = Ulid.NewUlid(),
                Name = u.Name,
                Email = u.Email,
                UserName = u.Email,
                PhoneNumber = u.Phone ?? u.PhoneNumber,
                Phone = u.Phone ?? u.PhoneNumber,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                NID = u.NID,
                Age = u.Age ?? 0
            };

            var createResult = await userManager.CreateAsync(newUser, u.Password);
            if (!createResult.Succeeded)
            {
                logger.LogError("Failed to create user {Email}: {Errors}", u.Email,
                    string.Join(", ", createResult.Errors.Select(e => e.Description)));
                continue;
            }

            var roleResult = await userManager.AddToRoleAsync(newUser, u.Role);
            if (!roleResult.Succeeded)
            {
                logger.LogError("Failed to assign role {Role} to user {Email}: {Errors}", u.Role, u.Email,
                    string.Join(", ", roleResult.Errors.Select(e => e.Description)));
            }
            else
            {
                logger.LogInformation("Successfully created user {Email} with role {Role}", u.Email, u.Role);
            }
        }

        logger.LogInformation("Finished seeding users");
    }

    private static string CleanJson(string json)
    {
        if (string.IsNullOrEmpty(json)) return json;

        // Remove BOM if present
        if (json[0] == '\uFEFF') json = json.Substring(1);

        // Remove simple // line comments to tolerate files edited on other machines
        var lines = json.Split(new[] { '\r', '\n' }, StringSplitOptions.None);
        var cleaned = lines.Where(l => !l.TrimStart().StartsWith("//")).ToArray();
        return string.Join(Environment.NewLine, cleaned);
    }

    private sealed class UserData
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty; // matches JSON "Phone"
        public string? PhoneNumber { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string NID { get; set; } = string.Empty;
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public string? Status { get; set; }
    }
}