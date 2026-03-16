using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.finance.Budget.Specifications;
using Domain.Entities;
using Domain.Models.Finance.Budget;
using SharedKernel;

namespace Application.Features.finance.Budget.Commands.Delete;

public class DeleteBudgetCommandHandler(IRepository<Domain.Models.Finance.Budget.Budget> repository) : ICommandHandler<DeleteBudgetCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.FirstOrDefaultAsync(new GetBudgetByIdSpec(request.Id), cancellationToken);
        if (user is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(BudgetMessageKeys.BudgetNotFound));
        }

        await repository.DeleteAsync(user, cancellationToken);
        return Result.Success(user.Id);
    }
}