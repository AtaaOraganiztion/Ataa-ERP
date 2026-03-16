using Application.Abstractions.Messaging;
using Application.Features.finance.Budget.Dtos;


namespace Application.Features.finance.Budget.Queries.GetAll;

public record GetBudgetQuery(BudgetFilter BudgetFilter) : IQuery<List<GetBudgetDto>>;