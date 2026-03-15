using Application.Abstractions.Messaging;
using Application.Features.finance.Budget.Dtos;


namespace Application.Features.finance.Budget.Queries.GetById;

public record GetBudgetByIdQuery(Ulid Id) : IQuery<GetBudgetDto>;