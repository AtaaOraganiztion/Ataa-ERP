using Domain.Enums;

namespace Application.Features.Identities.Dtos;

public record UpdateUserDto(
    string Name,
    string PhoneNumber,
    string Email,
    string NID,
    int Age,
    Gender? Gender
);
