using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.GlobalActivity.Commands.Delete;
using Application.Features.CRM.GlobalActivity.Specifications;
using Domain.Models.CRM.GlobalActivity;
using SharedKernel;

namespace Application.Features.CRM.GlobalActivity.Commands.Delete;

public class DeleteGlobalActivityCommandHandler(
    IRepository<Domain.Models.CRM.GlobalActivity.GlobalActivity> repository)
    : ICommandHandler<DeleteGlobalActivityCommand>
{
    public async Task<Result> Handle(DeleteGlobalActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await repository.FirstOrDefaultAsync(
            new GlobalActivityByIdSpec(request.Id), cancellationToken);

        if (activity is null)
            return Result.Failure(Error.NotFound(GlobalActivityMessageKeys.GlobalActivityNotFound));

        await repository.DeleteAsync(activity, cancellationToken);
        return Result.Success();
    }
}
