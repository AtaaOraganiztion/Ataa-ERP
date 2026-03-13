using Domain.Entities.Enums;
using Domain.Enums;

namespace Application.Features.User.Dtos;

public record GetUserDto(
  Ulid UserId,
 string? Name, 
 string? Phone,
 string? NID, 
 int? Age,
 Gender? Gender,
 UserStatus Status ,
 DateTime? LastLoginDate 
);