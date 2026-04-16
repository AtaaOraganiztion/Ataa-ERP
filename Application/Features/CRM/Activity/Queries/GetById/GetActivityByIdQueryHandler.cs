using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Activity.Dtos;
using Application.Features.CRM.Activity.Queries.GetById;
using Application.Features.CRM.Activity.Specifications;
using AutoMapper;
using Domain.Models.CRM.Activity;
using SharedKernel;

namespace Application.Features.CRM.Activity.Queries.GetById;

public class GetActivityByIdQueryHandler(IRepository<Domain.Models.CRM.Activity.Activity> repository, IMapper mapper) : IQueryHandler<GetActivityByIdQuery, GetActivityDto>
{
    public async Task<Result<GetActivityDto>> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.CRM.Activity.Activity? Activity = await repository.FirstOrDefaultAsync(new ActivityByIdSpec(request.Id), cancellationToken);
        if (Activity is null)
        {
            return Result.Failure<GetActivityDto>(Error.NotFound(ActivityMessageKeys.ActivityNotFound));
        }
        GetActivityDto ActivityDto = mapper.Map<GetActivityDto>(Activity);
        return Result.Success(ActivityDto);
    }
}