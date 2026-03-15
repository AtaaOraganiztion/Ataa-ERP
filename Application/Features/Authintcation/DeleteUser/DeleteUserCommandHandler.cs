using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Authintcation.DeleteUser;
using Application.Features.Identities.Specifications;
using Domain.Entities;
using SharedKernel;

namespace Application.Features.User.Commands.Delete;

public class DeleteUserCommandHandler(IRepository<Domain.Entities.User> repository) : ICommandHandler<DeleteUserCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.FirstOrDefaultAsync(new UserByIdSpec(request.Id),cancellationToken);
        if (employee is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(UserMessageKeys.UserNotFound));
        }

        await repository.DeleteAsync(employee, cancellationToken);
        return Result.Success(employee.Id);
    }
}