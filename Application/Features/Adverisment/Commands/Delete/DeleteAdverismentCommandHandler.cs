using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Models.Adverisment;
using SharedKernel;

namespace Application.Features.Adverisment.Commands.Delete;

public class DeleteActivityCommandHandler(
    IRepository<Domain.Models.Adverisment.Adverisment> repository)
    : ICommandHandler<DeleteAdverismentCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteAdverismentCommand request, CancellationToken cancellationToken)
    {
        var activity = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (activity is null)
            return Result.Failure<Ulid>(Error.NotFound(AdverismentMessageKeys.AdverismentNotFound));

        await repository.DeleteAsync(activity, cancellationToken);
        return Result.Success(activity.Id);
    }
}