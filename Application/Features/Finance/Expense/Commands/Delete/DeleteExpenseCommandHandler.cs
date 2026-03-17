using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Finance.Expense.Specifications;
using Domain.Entities;
using Domain.Models.Finance.Expense;
using SharedKernel;

namespace Application.Features.Finance.Expense.Commands.Delete;

public class DeleteExpenseCommandHandler(IRepository<Domain.Models.Finance.Expense.Expense> repository) : ICommandHandler<DeleteExpenseCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await repository.FirstOrDefaultAsync(new GetExpenseByIdSpec(request.Id), cancellationToken);
        if (expense is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(ExpenseMessageKeys.ExpenseNotFound));
        }

        await repository.DeleteAsync(expense, cancellationToken);
        return Result.Success(expense.Id);
    }
}