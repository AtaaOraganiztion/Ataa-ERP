using SharedKernel;

namespace Domain.FileUploads;

public class FileUpload : Entity, IAuditableEntity
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public string ContentType { get; set; }
    public long Size { get; set; }
    public string Hash { get; set; }
    public FileUploadFor UploadFor { get; set; }

    public Ulid CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Ulid LastModifiedBy { get; set; }
    public DateTime LastModifiedOnUtc { get; set; }
}
