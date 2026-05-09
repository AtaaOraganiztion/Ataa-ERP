using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.GlobalActivity.Dtos;
using Application.Features.CRM.GlobalActivity.Queries.GetById;
using Application.Features.CRM.GlobalActivity.Specifications;
using Domain.Models.CRM.GlobalActivity;
using AutoMapper;
using SharedKernel;

namespace Application.Features.CRM.GlobalActivity.Queries.GetById;

public class GetGlobalActivityQueryHandler(
    IRepository<Domain.Models.CRM.GlobalActivity.GlobalActivity> repository,
    IMapper mapper)
    : IQueryHandler<GetGlobalActivityQuery, GetGlobalActivityDto>
{
    public async Task<Result<GetGlobalActivityDto>> Handle(GetGlobalActivityQuery request, CancellationToken cancellationToken)
    {
        var activity = await repository.FirstOrDefaultAsync(
            new GlobalActivityByIdSpec(request.Id), cancellationToken);

        if (activity is null)
            return Result.Failure<GetGlobalActivityDto>(Error.NotFound(GlobalActivityMessageKeys.GlobalActivityNotFound));

        return mapper.Map<GetGlobalActivityDto>(activity);
    }
}
