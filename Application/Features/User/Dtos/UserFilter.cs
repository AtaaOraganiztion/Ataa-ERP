
using Domain.Entities.Enums;
using Domain.Enums;

namespace Application.Features.User.Dtos;

public record UserFilter(
    Ulid UserId,
 string? Name,
 string? Phone,
 string? NID,
 int? Age,
 Gender? Gender,
 UserStatus Status,
 DateTime? LastLoginDate

    );