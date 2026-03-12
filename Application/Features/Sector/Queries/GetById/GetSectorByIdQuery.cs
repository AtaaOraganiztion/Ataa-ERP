using Application.Abstractions.Messaging;
using Application.Features.Sector.Dtos;


namespace Application.Features.Sector.Queries.GetById;

public record GetSectorByIdQuery(Ulid Id) : IQuery<GetSectorDto>;