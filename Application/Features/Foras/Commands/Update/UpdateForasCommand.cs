using Application.Abstractions.Messaging;
using Application.Features.Foras.Dtos;

namespace Application.Features.Foras.Commands.Update;

public record UpdateForasCommand(Ulid Id, UpdateForasDto Request) : ICommand<Ulid>;
