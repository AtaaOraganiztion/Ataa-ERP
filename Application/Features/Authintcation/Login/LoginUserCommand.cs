using Application.Abstractions.Messaging;
using Application.Features.Identities.Dtos;

namespace Application.Features.Identities.Users.Login;

public record LoginUserCommand(
    string Email,
    string Password
) : ICommand<TokenResponseDto>;
