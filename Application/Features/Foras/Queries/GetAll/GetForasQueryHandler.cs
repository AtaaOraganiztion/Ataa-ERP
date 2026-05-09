using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Foras.Dtos;
using Application.Features.Foras.Specifications;
using Application.Features.Foras.Queries.GetAll;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Foras.Queries.GetAll;

public class GetForasQueryHandler(
    IRepository<Domain.Models.Foras.Foras> repository,
    IMapper mapper)
    : IQueryHandler<GetForasQuery, List<GetForasDto>>
{
    public async Task<Result<List<GetForasDto>>> Handle(GetForasQuery request, CancellationToken cancellationToken)
    {
        var foras = await repository.ListAsync(
            new GetForasSpec(request.Filter),
            cancellationToken);

        var forasDtos = mapper.Map<List<GetForasDto>>(foras);

        return Result.Success(forasDtos);
    }
}
