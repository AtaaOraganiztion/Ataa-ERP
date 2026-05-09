using Application.Abstractions.Messaging;
using Application.Features.Adverisment.Dtos;

namespace Application.Features.Adverisment.Queries.GetById;

public record GetAdverismentByIdQuery(Ulid Id) : IQuery<GetAdverismentDto>;