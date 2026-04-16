using Application.Abstractions.Messaging;

namespace Application.Features.CRM.Lead.Commands.Delete;

public record DeleteLeadCommand(Ulid Id) : ICommand<Ulid>;