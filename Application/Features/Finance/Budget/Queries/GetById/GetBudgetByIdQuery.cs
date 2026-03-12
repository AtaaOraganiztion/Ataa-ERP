using Application.Abstractions.Messaging;
using Application.Features.Budget.Dtos;


namespace Application.Features.Budget.Queries.GetById;

public record GetBudgetByIdQuery(Ulid Id) : IQuery<GetBudgetDto>;