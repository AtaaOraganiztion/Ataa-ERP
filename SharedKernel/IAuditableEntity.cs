namespace SharedKernel;

public interface IAuditableEntity
{
    Ulid CreatedBy { get; set; }
    DateTime CreatedOnUtc { get; set; }
    Ulid LastModifiedBy { get; set; }
    DateTime LastModifiedOnUtc { get; set; }
}
