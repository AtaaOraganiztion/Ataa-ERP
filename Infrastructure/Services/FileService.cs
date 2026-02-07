// using System.Security.Cryptography;

using System.Security.Cryptography;
using Application.Abstractions.Services;
using Domain.FileUploads;
using Infrastructure.Database;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class FileService(ApplicationDbContext dbContext, ServerSetting serverSetting) : IFileService
{
    private readonly string _mainServerUrl = serverSetting.BaseUrl;
    private readonly string _mainDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");


    public async Task<string> UploadFileAsync(FileUpload fileUpload, Stream stream,
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Generate a unique file path to prevent overwriting
            string uniqueFileName = $"{fileUpload.Id}{fileUpload.Extension}";

            // Ensure the uploads directory exists
            string uploadsDirectory = Path.Combine(_mainDirectory, fileUpload.UploadFor.ToString());
            // Assuming the directory is relative to the application's base directory
            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            string filePath = Path.Combine(uploadsDirectory, uniqueFileName);

            // Write the file to disk using buffer for improved performance
            await using FileStream fileStream = new(filePath, FileMode.Create);
            await stream.CopyToAsync(fileStream, 81920, cancellationToken);

            await dbContext.Set<FileUpload>().AddAsync(fileUpload, cancellationToken);
            
            await dbContext.SaveChangesAsync(cancellationToken);

            return Path.Combine(fileUpload.UploadFor.ToString(), uniqueFileName);
        }
        catch (Exception ex)
        {
            // Use more specific exception type and remove undefined fileName variable
            throw new IOException($"Failed to upload file with extension {fileUpload}", ex);
        }
    }

    public async Task<string> GetFileHash(Stream stream, CancellationToken cancellationToken = default)
    {
        using HashAlgorithm hashAlgorithm = SHA256.Create();
        byte[] hashBytes = await hashAlgorithm.ComputeHashAsync(stream, cancellationToken);
        return Convert.ToHexString(hashBytes).ToLowerInvariant();
    }

    public async Task DeleteFileAsync(string filePath, CancellationToken cancellationToken = default)
    {
        if (File.Exists(filePath))
        {
            await Task.Run(() => File.Delete(filePath), cancellationToken);
        }
    }

    public string? GetFileUrl(string? filePath)
    {
        return string.IsNullOrEmpty(filePath) ? null : Path.Combine(_mainServerUrl, filePath);
    }

    public string? GetFilePath(string? filePath)
    {
        return string.IsNullOrEmpty(filePath) ? null : Path.Combine(_mainDirectory, filePath);
    }

    public Dictionary<Ulid, string> GetFilePathsFromIds(List<Ulid> fileIds)
    {
        if (!fileIds.Any())
        {
            return new Dictionary<Ulid, string>();
        }

        return dbContext.Set<FileUpload>()
            .AsNoTracking()
            .Where(f => fileIds.Contains(f.Id))
            .ToDictionary(
                f => f.Id,
                f => Path.Combine(f.UploadFor.ToString(), f.Id + f.Extension)
            );
    }

    public List<string> GetExistingFilePathsFromIds(List<Ulid> fileIds)
    {
        var paths = dbContext.Set<FileUpload>()
            .AsNoTracking()
            .Where(f => fileIds.Contains(f.Id))
            .Select(f => Path.Combine(f.UploadFor.ToString(), f.Id + f.Extension))
            .ToList();

        // Only return paths that actually exist on disk
        return paths.Where(path => !string.IsNullOrEmpty(path) && File.Exists(Path.Combine(_mainDirectory, path)))
            .ToList();
    }

    public string GetFilePathFromId(Ulid fileId)
    {
        string? path = dbContext.Set<FileUpload>()
            .AsNoTracking()
            .Where(f => f.Id.Equals(fileId))
            .Select(f => Path.Combine(f.UploadFor.ToString(), f.Id + f.Extension))
            .FirstOrDefault();

        // Check if the file actually exists on disk
        return string.IsNullOrEmpty(path) || !File.Exists(Path.Combine(_mainDirectory, path))
            ? null
            : path;
    }
}
