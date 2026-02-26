using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.Features.Identities.Users.Register;

public record RegisterUserCommand(
    string Name,
    string Email,
    string PhoneNumber,
    int Age,
    string NID,
    Gender? Gender,
    string Password
) : ICommand;
