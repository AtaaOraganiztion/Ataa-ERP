using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Models.CRM.Activity;
using SharedKernel;
using Application.Features.CRM.Activity.Specifications;

namespace Application.Features.CRM.Activity.Queries.GetFileById;

public class GetActivityFileByIdQueryHandler(
    IRepository<Domain.Models.CRM.Activity.Activity> repository)
    : IQueryHandler<GetActivityFileByIdQuery, Domain.Models.CRM.Activity.Activity.File>
{
    public async Task<Result<Domain.Models.CRM.Activity.Activity.File>> Handle(
        GetActivityFileByIdQuery request,
        CancellationToken cancellationToken)
    {
        var activity = await repository.FirstOrDefaultAsync(
            new ActivityFileByIdSpec(request.FileId),
            cancellationToken);

        var file = activity?.Files.FirstOrDefault(f => f.Id == request.FileId);

        if (file is null)
            return Result.Failure<Domain.Models.CRM.Activity.Activity.File>(
                Error.NotFound("File not found"));

        return Result.Success(file);
    }
}