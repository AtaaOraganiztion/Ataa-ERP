using Application.Abstractions.Messaging;
using Application.Features.Finance.Expense.Dtos;


namespace Application.Features.Finance.Expense.Queries.GetById;

public record GetExpenseByIdQuery(Ulid Id) : IQuery<GetExpenseDto>;