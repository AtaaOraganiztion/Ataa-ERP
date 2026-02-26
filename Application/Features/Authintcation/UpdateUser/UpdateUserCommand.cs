using Application.Abstractions.Messaging;
using Application.Features.Identities.Dtos;

namespace Application.Features.Identities.Users.UpdateUser;

public record UpdateUserCommand(Ulid UserId, UpdateUserDto UpdateUserDto) : ICommand;
