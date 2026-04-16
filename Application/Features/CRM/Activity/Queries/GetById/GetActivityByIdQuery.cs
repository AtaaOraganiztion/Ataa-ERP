using Application.Abstractions.Messaging;
using Application.Features.CRM.Activity.Dtos;

namespace Application.Features.CRM.Activity.Queries.GetById;

public record GetActivityByIdQuery(Ulid Id) : IQuery<GetActivityDto>;
