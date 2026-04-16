using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Models.CRM.Activity;
using SharedKernel;

namespace Application.Features.CRM.Activity.Commands.Delete;

public class DeleteActivityCommandHandler(
    IRepository<Domain.Models.CRM.Activity.Activity> repository)
    : ICommandHandler<DeleteActivityCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (activity is null)
            return Result.Failure<Ulid>(Error.NotFound(ActivityMessageKeys.ActivityNotFound));

        await repository.DeleteAsync(activity, cancellationToken);
        return Result.Success(activity.Id);
    }
}