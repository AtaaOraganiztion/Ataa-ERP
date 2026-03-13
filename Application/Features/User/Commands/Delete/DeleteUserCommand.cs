using Application.Abstractions.Messaging;

namespace Application.Features.User.Commands.Delete;

public record DeleteUserCommand(Ulid Id) : ICommand<Ulid>;