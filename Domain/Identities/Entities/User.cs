using Microsoft.AspNetCore.Identity;
using SharedKernel;

namespace Domain.Identities.Entities;

public class User : IdentityUser<Ulid>
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    // Navigation properties
    [NavigationalProperty] 
    public virtual ICollection<UserDevice> UserDevices { get; set; } = null!;
}
