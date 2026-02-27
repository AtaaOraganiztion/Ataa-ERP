using Domain.Enums;

namespace Application.Features.Identities.Dtos;

public record UserInfoDto(
    Ulid Id,
    string Name,
    string Email,
    bool EmailConfirmed,
    string PhoneNumber,
    string? ProfileImage,
    bool LockoutEnabled,
    DateTimeOffset? LockoutEnd,
    DateTime? LastLoginAt,
    string? NID,
    int Age,
    Gender? Gender,
    IList<string> Roles
);

