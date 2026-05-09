using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Adverisment.Dtos;
using Application.Features.Adverisment.Specifications;
using AutoMapper;
using Domain.Models.Adverisment;
using SharedKernel;

namespace Application.Features.Adverisment.Queries.GetById;

public class GetAdverismentByIdQueryHandler(
    IRepository<Domain.Models.Adverisment.Adverisment> repository,
    IMapper mapper)
    : IQueryHandler<GetAdverismentByIdQuery, GetAdverismentDto>
{
    public async Task<Result<GetAdverismentDto>> Handle(
        GetAdverismentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var adverisment = await repository.FirstOrDefaultAsync(
            new AdverismentByIdSpec(request.Id),
            cancellationToken);

        if (adverisment is null)
            return Result.Failure<GetAdverismentDto>(
                Error.NotFound(AdverismentMessageKeys.AdverismentNotFound));

        var adverismentDto = mapper.Map<GetAdverismentDto>(adverisment);
        return Result.Success(adverismentDto);
    }
}