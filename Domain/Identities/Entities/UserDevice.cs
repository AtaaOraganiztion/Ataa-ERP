using Microsoft.AspNetCore.Identity;
using SharedKernel;

namespace Domain.Identities.Entities;

public class UserDevice : Entity, IAuditableEntity
{
    public Ulid UserId { get; set; }
    public string DeviceId { get; set; } = null!;
    public string DeviceType { get; set; } = null!;
    public string DeviceName { get; set; } = null!;
    public string? Browser { get; set; }
    public string? UserAgent { get; set; }
    public DateTime LoginDate { get; set; }
    public DateTime? LastActivityDate { get; set; }
    public bool IsActive { get; set; }
    public string? AccessToken { get; set; }
    public DateTime? TokenExpiryDate { get; set; }
    public string IpAddress { get; set; } = null!;

    // Navigation property
    public virtual User User { get; set; } = null!;
    public Ulid CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Ulid LastModifiedBy { get; set; }
    public DateTime LastModifiedOnUtc { get; set; }
}
