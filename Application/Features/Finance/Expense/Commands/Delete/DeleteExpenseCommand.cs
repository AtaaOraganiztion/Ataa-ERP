using Application.Abstractions.Messaging;

namespace Application.Features.Finance.Expense.Commands.Delete;

public record DeleteExpenseCommand(Ulid Id) : ICommand<Ulid>;