using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Adverisment.Dtos;
using Application.Features.Adverisment.Specifications;
using Application.Features.Adverisment.Queries.GetAll;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Adverisment.Queries.GetAll;

public class GetAdverismentQueryHandler(
    IRepository<Domain.Models.Adverisment.Adverisment> repository,
    IMapper mapper)
    : IQueryHandler<GetAdverismentQuery, List<GetAdverismentDto>>
{
    public async Task<Result<List<GetAdverismentDto>>> Handle(GetAdverismentQuery request, CancellationToken cancellationToken)
    {
        var activities = await repository.ListAsync(
            new GetAdverismentSpec(request.Filter),
            cancellationToken);

        var activityDtos = mapper.Map<List<GetAdverismentDto>>(activities);

        return Result.Success(activityDtos);
    }
}
