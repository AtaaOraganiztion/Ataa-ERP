using Domain.Entities.Enums;
using Domain.Enums;

namespace Application.Features.Identities.Dtos;

public record UserDto(
    Ulid Id,
    string Name,
    string Phone,
    string Email,
    string NID,
    int? Age,
    Gender? Gender,
    UserStatus? Status,
    DateTime? LastLoginAt);
