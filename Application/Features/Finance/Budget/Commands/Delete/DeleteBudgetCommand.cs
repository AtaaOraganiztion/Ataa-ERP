using Application.Abstractions.Messaging;

namespace Application.Features.finance.Budget.Commands.Delete;

public record DeleteBudgetCommand(Ulid Id) : ICommand<Ulid>;