using Application.Abstractions.Messaging;

namespace Application.Features.Adverisment.Commands.Delete;

public record DeleteAdverismentCommand(Ulid Id) : ICommand<Ulid>;