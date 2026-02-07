using Domain.FileUploads;

namespace Application.Abstractions.Services;

public interface IFileService
{
    Task<string> UploadFileAsync(FileUpload fileUpload, Stream stream, CancellationToken cancellationToken = default);

    Task<string> GetFileHash(Stream stream, CancellationToken cancellationToken = default);

    Task DeleteFileAsync(string filePath, CancellationToken cancellationToken = default);

    string? GetFileUrl(string? filePath);

    string? GetFilePath(string? filePath);
    Dictionary<Ulid, string> GetFilePathsFromIds(List<Ulid> fileIds);
    string GetFilePathFromId(Ulid fileId);
}
