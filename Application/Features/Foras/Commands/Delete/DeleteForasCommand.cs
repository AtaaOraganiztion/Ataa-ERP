using Application.Abstractions.Messaging;

namespace Application.Features.Foras.Commands.Delete;

public record DeleteForasCommand(Ulid Id) : ICommand<Ulid>;
