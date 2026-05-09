using Application.Abstractions.Messaging;
using Application.Features.Foras.Dtos;

namespace Application.Features.Foras.Queries.GetById;

public record GetForasByIdQuery(Ulid Id) : IQuery<GetForasDto>;
