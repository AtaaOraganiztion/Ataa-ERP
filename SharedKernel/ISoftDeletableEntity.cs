namespace SharedKernel;

public interface ISoftDeletableEntity
{
    bool IsDeleted { get; set; }
    DateTime DeletedOnUtc { get; set; }
}
