using Application.Abstractions.Messaging;

namespace Application.Features.Budget.Commands.Delete;

public record DeleteBudgetCommand(Ulid Id) : ICommand<Ulid>;