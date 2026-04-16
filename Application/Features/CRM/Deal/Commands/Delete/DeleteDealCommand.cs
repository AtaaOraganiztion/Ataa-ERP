using Application.Abstractions.Messaging;

namespace Application.Features.CRM.Deal.Commands.Delete;

public record DeleteDealCommand(Ulid Id) : ICommand<Ulid>;