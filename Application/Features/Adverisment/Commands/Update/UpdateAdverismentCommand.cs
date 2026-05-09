using Application.Abstractions.Messaging;
using Application.Features.Adverisment.Dtos;

namespace Application.Features.Adverisment.Commands.Update;

public record UpdateAdverismentCommand(Ulid Id, UpdateAdverismentDto Request) : ICommand<Ulid>;