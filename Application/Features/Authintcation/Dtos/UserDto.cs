namespace Application.Features.Identities.Dtos;

public record UserDto(
    Ulid Id,
    string Name,
    string Email,
    bool EmailConfirmed,
    string PhoneNumber,
    string? ProfileImage,
    bool IsLockoutEnabled,
    DateTimeOffset? LockoutEnd,
    DateTime RegistrationDate,
    DateTime LastLoginAt,
    IList<string> Roles
);
