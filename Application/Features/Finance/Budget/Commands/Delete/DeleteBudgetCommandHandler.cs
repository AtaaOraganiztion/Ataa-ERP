using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.User.Commands.Delete;
using Application.Features.User.Specifications;
using Domain.Entities;
using SharedKernel;

namespace Application.Features.finance.Budget.Commands.Delete;

public class DeleteUserCommandHandler(IRepository<Domain.Entities.User> repository) : ICommandHandler<DeleteUserCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.FirstOrDefaultAsync(new UserByIdSpec(request.Id), cancellationToken);
        if (user is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(UserMessageKeys.UserNotFound));
        }

        await repository.DeleteAsync(user, cancellationToken);
        return Result.Success(user.Id);
    }
}