using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.GlobalActivity.Dtos;
using Application.Features.CRM.GlobalActivity.Specifications;
using Domain.Models.CRM.GlobalActivity;
using AutoMapper;
using SharedKernel;

namespace Application.Features.CRM.GlobalActivity.Queries.GetList;

public class GetGlobalActivitiesQueryHandler(
    IRepository<Domain.Models.CRM.GlobalActivity.GlobalActivity> repository,
    IMapper mapper)
    : IQueryHandler<GetGlobalActivitiesQuery, List<GetGlobalActivityDto>>
{
    public async Task<Result<List<GetGlobalActivityDto>>> Handle(GetGlobalActivitiesQuery request, CancellationToken cancellationToken)
    {
        var activities = await repository.ListAsync(new GlobalActivitySpec(request.Filter), cancellationToken);
        return mapper.Map<List<GetGlobalActivityDto>>(activities);
    }
}
