using Domain.Identities.Enums;
using SharedKernel;

namespace Domain.Identities.Entities;

public class UserCode : Entity
{
    public Ulid UserId { get; set; }
    public string Code { get; set; } = null!;
    public string Token { get; set; } = null!;

    public int ExpiresIn { get; set; }
    public CodePurpose Purpose { get; set; }

    public CodeUsageType? UsageType { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; } = null!;
}
