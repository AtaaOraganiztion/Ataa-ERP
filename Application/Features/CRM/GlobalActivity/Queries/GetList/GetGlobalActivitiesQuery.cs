using Application.Abstractions.Messaging;
using Application.Features.CRM.GlobalActivity.Dtos;

namespace Application.Features.CRM.GlobalActivity.Queries.GetList;

public record GetGlobalActivitiesQuery(GlobalActivityFilter? Filter = null) : IQuery<List<GetGlobalActivityDto>>;
