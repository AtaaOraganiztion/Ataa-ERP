using Application.Abstractions.Messaging;

namespace Application.Features.Finance.Budget.Commands.Delete;

public record DeleteBudgetCommand(Ulid Id) : ICommand<Ulid>;
