using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Models.Foras;
using SharedKernel;

namespace Application.Features.Foras.Commands.Delete;

public class DeleteForasCommandHandler(
    IRepository<Domain.Models.Foras.Foras> repository)
    : ICommandHandler<DeleteForasCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteForasCommand request, CancellationToken cancellationToken)
    {
        var foras = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (foras is null)
            return Result.Failure<Ulid>(Error.NotFound(ForasMessageKeys.ForasNotFound));

        await repository.DeleteAsync(foras, cancellationToken);
        return Result.Success(foras.Id);
    }
}
