/*using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.User.Specifications;
using Domain.Entities;
using SharedKernel;

namespace Application.Features.User.Commands.Delete;

public class DeleteUserCommandHandler(IRepository<Domain.Entities.User> repository) : ICommandHandler<DeleteUserCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var Budget = await repository.FirstOrDefaultAsync(new UserByIdSpec(request.Id), cancellationToken);
        if (Budget is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(UserMessageKeys.UserNotFound));
        }

        await repository.DeleteAsync(Budget, cancellationToken);
        return Result.Success(Budget.Id);
    }
}*/