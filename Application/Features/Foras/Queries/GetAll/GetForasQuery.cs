using Application.Abstractions.Messaging;
using Application.Features.Foras.Dtos;

namespace Application.Features.Foras.Queries.GetAll;

public record GetForasQuery(ForasFilter Filter) : IQuery<List<GetForasDto>>;
