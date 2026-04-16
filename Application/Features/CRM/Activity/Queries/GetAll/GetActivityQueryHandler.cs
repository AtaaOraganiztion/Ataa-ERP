using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Activity.Dtos;
using Application.Features.CRM.Activity.Specifications;
using Application.Features.CRM.Activity.Queries.GetAll;
using AutoMapper;
using SharedKernel;

namespace Application.Features.CRM.Activity.Queries.GetAll;

public class GetActivityQueryHandler(
    IRepository<Domain.Models.CRM.Activity.Activity> repository,
    IMapper mapper)
    : IQueryHandler<GetActivityQuery, List<GetActivityDto>>
{
    public async Task<Result<List<GetActivityDto>>> Handle(GetActivityQuery request, CancellationToken cancellationToken)
    {
        var activities = await repository.ListAsync(
            new GetActivitySpec(request.Filter),
            cancellationToken);

        var activityDtos = mapper.Map<List<GetActivityDto>>(activities);

        return Result.Success(activityDtos);
    }
}
