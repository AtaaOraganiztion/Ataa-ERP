using Application.Abstractions.Messaging;

namespace Application.Features.CRM.Activity.Commands.Delete;

public record DeleteActivityCommand(Ulid Id) : ICommand<Ulid>;