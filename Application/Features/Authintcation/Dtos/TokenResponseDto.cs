namespace Application.Features.Identities.Dtos;

public record TokenResponseDto(
    string AccessToken,
    double ExpiresIn,
    string TokenType,
    Ulid SessionState
);
