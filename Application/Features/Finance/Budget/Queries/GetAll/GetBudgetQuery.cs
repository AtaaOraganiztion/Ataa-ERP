using Application.Abstractions.Messaging;
using Application.Features.Budget.Dtos;


namespace Application.Features.Budget.Queries.GetAll;

public record GetBudgetQuery(BudgetFilter BudgetFilter) : IQuery<List<GetBudgetDto>>;