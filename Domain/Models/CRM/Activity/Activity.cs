using Domain.Entities;
using Domain.Enums.CRM;
using SharedKernel;
using SharedKernel.Common;
using Domain.Enums;
namespace Domain.Models.CRM.Activity;

public class Activity : Entity, ISoftDeletableEntity
{
    public ActivityType Type { get; set; }
    public ActivityResult? ActivityResult { get; set; }
    public string Subject { get; set; }
    public string? Description { get; set; }
    public DateTime ActivityDate { get; set; }
    public ActivityStatus Status { get; set; }
    public Ulid? CustomerId { get; set; }
    public Ulid? LeadId { get; set; }
    public Ulid? DealId { get; set; }
    public Ulid? AssignedToUserId { get; set; }
    public Ulid? CreatedByUserId { get; set; }

    public virtual Customer.Customer? Customer { get; set; }
    public virtual Lead.Lead? Lead { get; set; }
    public virtual Deal.Deal? Deal { get; set; }
    public virtual User? AssignedTo { get; set; }
    public virtual User? CreatedBy { get; set; }

    public virtual ICollection<File> Files { get; set; } = new List<File>();

    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }

    public class File : Entity
    {
        public Ulid ActivityId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string StoragePath { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long FileSizeInBytes { get; set; }
        public DateTime UploadedAtUtc { get; set; }
        public Ulid? CreatedByUserId { get; set; }

        public virtual Activity? Activity { get; set; }
        public virtual User? User { get; set; }
    }
}