using Microsoft.AspNetCore.Http;

namespace Application.Abstractions.Services;

public interface IUploadImage
{
    Task<string> SaveFileAsync(IFormFile file, string folderName);
    Task DeleteFileAsync(string filePath);
}