using Application.Abstractions.Messaging;
using Application.Features.Finance.Expense.Dtos;

namespace Application.Features.Finance.Expense.Commands.Update;

public record UpdateExpenseCommand(Ulid Id, UpdateExpenseDto? ExpenseDto) : ICommand<Ulid>;
