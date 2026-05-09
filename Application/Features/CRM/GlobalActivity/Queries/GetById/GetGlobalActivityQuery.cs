using Application.Abstractions.Messaging;
using Application.Features.CRM.GlobalActivity.Dtos;

namespace Application.Features.CRM.GlobalActivity.Queries.GetById;

public record GetGlobalActivityQuery(Ulid Id) : IQuery<GetGlobalActivityDto>;
