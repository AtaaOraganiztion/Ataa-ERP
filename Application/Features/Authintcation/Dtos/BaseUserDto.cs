namespace Application.Features.Identities.Dtos;

public record BaseUserDto(Ulid Id,
    string Name,
    string Email,
    bool EmailConfirmed,
    string PhoneNumber,
    string? ProfileImage);