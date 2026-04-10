using Application.Abstractions.Messaging;
using Application.Features.Finance.Budget.Dtos;


namespace Application.Features.Finance.Budget.Queries.GetAll;

public record GetBudgetQuery(BudgetFilter BudgetFilter) : IQuery<List<GetBudgetDto>>;
