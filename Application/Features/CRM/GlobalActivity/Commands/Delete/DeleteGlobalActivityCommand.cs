using Application.Abstractions.Messaging;

namespace Application.Features.CRM.GlobalActivity.Commands.Delete;

public record DeleteGlobalActivityCommand(Ulid Id) : ICommand;
