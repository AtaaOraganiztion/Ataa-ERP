using Application.Abstractions.Messaging;

namespace Application.Features.Authintcation.DeleteUser;

public record DeleteUserCommand(Ulid Id) : ICommand<Ulid>;