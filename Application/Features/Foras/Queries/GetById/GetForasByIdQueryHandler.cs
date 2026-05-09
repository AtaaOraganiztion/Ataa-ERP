using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Foras.Dtos;
using Application.Features.Foras.Specifications;
using AutoMapper;
using Domain.Models.Foras;
using SharedKernel;

namespace Application.Features.Foras.Queries.GetById;

public class GetForasByIdQueryHandler(
    IRepository<Domain.Models.Foras.Foras> repository,
    IMapper mapper)
    : IQueryHandler<GetForasByIdQuery, GetForasDto>
{
    public async Task<Result<GetForasDto>> Handle(
        GetForasByIdQuery request,
        CancellationToken cancellationToken)
    {
        var foras = await repository.FirstOrDefaultAsync(
            new ForasByIdSpec(request.Id),
            cancellationToken);

        if (foras is null)
            return Result.Failure<GetForasDto>(
                Error.NotFound(ForasMessageKeys.ForasNotFound));

        var forasDto = mapper.Map<GetForasDto>(foras);
        return Result.Success(forasDto);
    }
}
