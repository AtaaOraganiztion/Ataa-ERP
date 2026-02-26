using Application.Abstractions.Messaging;
using Application.Features.Identities.Dtos;

namespace Application.Features.Identities.Users.UpdateMe;

public record UpdateMeCommand(UpdateUserDto UpdateUserDto) : ICommand;
