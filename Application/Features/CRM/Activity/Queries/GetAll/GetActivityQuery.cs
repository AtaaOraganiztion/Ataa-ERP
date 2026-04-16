using Application.Abstractions.Messaging;
using Application.Features.CRM.Activity.Dtos;

namespace Application.Features.CRM.Activity.Queries.GetAll;

public record GetActivityQuery(ActivityFilter Filter) : IQuery<List<GetActivityDto>>;