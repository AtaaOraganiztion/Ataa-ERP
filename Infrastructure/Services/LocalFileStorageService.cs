using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Application.Abstractions;

public class LocalFileStorageService(IConfiguration configuration) : IFileStorageService
{
    private readonly string _basePath = configuration["FileStorage:BasePath"] ?? "uploads";

    public async Task<string> SaveAsync(IFormFile file, CancellationToken cancellationToken = default)
    {
        var folder = Path.Combine(_basePath, "activities");
        Directory.CreateDirectory(folder);

        var uniqueName = $"{Ulid.NewUlid()}_{Path.GetFileName(file.FileName)}";
        var fullPath = Path.Combine(folder, uniqueName);

        await using var stream = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(stream, cancellationToken);

        return fullPath;
    }
    public Stream GetFileStream(string storagePath)
    {
        return File.OpenRead(storagePath);
    }
    public void Delete(string storagePath)
    {
        if (File.Exists(storagePath))
            File.Delete(storagePath);
    }
}