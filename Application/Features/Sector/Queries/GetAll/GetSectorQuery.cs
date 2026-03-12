using Application.Abstractions.Messaging;
using Application.Features.Sector.Dtos;


namespace Application.Features.Sector.Queries.GetAll;

public record GetSectorQuery(SectorFilter SectorFilter) : IQuery<List<GetSectorDto>>;