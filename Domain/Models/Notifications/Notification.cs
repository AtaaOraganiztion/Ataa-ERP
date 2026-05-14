using Domain.Entities;
using SharedKernel;
using SharedKernel.Common;

namespace Domain.Models.Notifications;

public class Notification : Entity, ISoftDeletableEntity
{
    public Ulid? UserId { get; set; }
    public Ulid? CreatedByUserId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Message { get; set; }
    public string? EntityType { get; set; }
    public Ulid? EntityId { get; set; }
    public string? Link { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; }
    public DateTime DeletedOnUtc { get; set; }
}
