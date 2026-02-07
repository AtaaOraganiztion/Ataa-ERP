using Application.Abstractions.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class UploadImage(IWebHostEnvironment env) : IUploadImage
{
    public async Task<string> SaveFileAsync(IFormFile file, string folderName)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is empty");

        string uploadsFolder = Path.Combine(env.WebRootPath, folderName);
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/{folderName}/{fileName}";
    }

    public async Task DeleteFileAsync(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return;

        var relativePath = filePath.TrimStart('/');

        var fullPath = Path.Combine(env.WebRootPath, relativePath);

        if (File.Exists(fullPath))
        {
            await Task.Run(() => File.Delete(fullPath));
        }
    }
}