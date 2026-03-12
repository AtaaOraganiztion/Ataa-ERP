using Application.Abstractions.Messaging;

namespace Application.Features.Sector.Commands.Delete;

public record DeleteSectorCommand(Ulid Id) : ICommand<Ulid>;