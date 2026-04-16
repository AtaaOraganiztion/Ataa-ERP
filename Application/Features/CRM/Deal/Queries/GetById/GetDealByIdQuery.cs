using Application.Abstractions.Messaging;
using Application.Features.CRM.Deal.Dtos;

namespace Application.Features.CRM.Deal.Queries.GetById;

public record GetDealByIdQuery(Ulid Id) : IQuery<GetDealDto>;