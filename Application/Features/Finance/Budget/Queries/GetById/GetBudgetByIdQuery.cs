using Application.Abstractions.Messaging;
using Application.Features.Finance.Budget.Dtos;


namespace Application.Features.Finance.Budget.Queries.GetById;

public record GetBudgetByIdQuery(Ulid Id) : IQuery<GetBudgetDto>;
