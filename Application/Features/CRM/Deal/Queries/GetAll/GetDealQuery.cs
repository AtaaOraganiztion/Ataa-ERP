using Application.Abstractions.Messaging;
using Application.Features.CRM.Deal.Dtos;

namespace Application.Features.CRM.Deal.Queries.GetAll;

public record GetDealQuery(DealFilter Filter) : IQuery<List<GetDealDto>>;