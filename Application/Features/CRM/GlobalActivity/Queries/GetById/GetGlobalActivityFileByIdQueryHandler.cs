using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Models.CRM.GlobalActivity;
using SharedKernel;
using Application.Features.CRM.GlobalActivity.Specifications;

namespace Application.Features.CRM.GlobalActivity.Queries.GetFileById;

public class GetGlobalActivityFileByIdQueryHandler(
    IRepository<Domain.Models.CRM.GlobalActivity.GlobalActivity> repository)
    : IQueryHandler<GetGlobalActivityFileByIdQuery, Domain.Models.CRM.GlobalActivity.GlobalActivity.File>
{
    public async Task<Result<Domain.Models.CRM.GlobalActivity.GlobalActivity.File>> Handle(
        GetGlobalActivityFileByIdQuery request,
        CancellationToken cancellationToken)
    {
        var activity = await repository.FirstOrDefaultAsync(
            new GlobalActivityFileByIdSpec(request.FileId),
            cancellationToken);

        var file = activity?.Files.FirstOrDefault(f => f.Id == request.FileId);

        if (file is null)
            return Result.Failure<Domain.Models.CRM.GlobalActivity.GlobalActivity.File>(
                Error.NotFound("File not found"));

        return Result.Success(file);
    }
}
