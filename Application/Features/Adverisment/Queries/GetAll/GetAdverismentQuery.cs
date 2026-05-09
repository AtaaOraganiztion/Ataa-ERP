using Application.Abstractions.Messaging;
using Application.Features.Adverisment.Dtos;

namespace Application.Features.Adverisment.Queries.GetAll;

public record GetAdverismentQuery(AdverismentFilter Filter) : IQuery<List<GetAdverismentDto>>;