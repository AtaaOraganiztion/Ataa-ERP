using Application.Abstractions.Messaging;
using Application.Features.Finance.Expense.Dtos;


namespace Application.Features.Finance.Expense.Queries.GetAll;

public record GetExpenseQuery(ExpenseFilter ExpenseFilter) : IQuery<List<GetExpenseDto>>;