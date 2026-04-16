
public interface IFileStorageService
{
    Task<string> SaveAsync(IFormFile file, CancellationToken cancellationToken = default);
    void Delete(string storagePath);
    Stream GetFileStream(string storagePath);

}