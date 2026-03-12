using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Budget.Specifications;
using Domain.Models.Employee;
using Domain.Models.Finance.Budget;
using SharedKernel;

namespace Application.Features.Budget.Commands.Delete;

public class DeleteBudgetCommandHandler(IRepository<Domain.Models.Finance.Budget.Budget> repository) : ICommandHandler<DeleteBudgetCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
    {
        var Budget = await repository.FirstOrDefaultAsync(new BudgetByIdSpec(request.Id), cancellationToken);
        if (Budget is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(BudgetMessageKeys.BudgetNotFound));
        }

        await repository.DeleteAsync(Budget, cancellationToken);
        return Result.Success(Budget.Id);
    }
}