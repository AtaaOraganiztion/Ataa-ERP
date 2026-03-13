using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Finance.Expense.Specifications;
using AutoMapper;
using Domain.Models.Finance.Expense;
using Application.Features.Finance.Expense.Dtos;
using SharedKernel;

namespace Application.Features.Finance.Expense.Commands.Update;

public class UpdateExpenseCommandHandler(IMapper mapper, IRepository<Domain.Models.Finance.Expense.Expense> repository) : ICommandHandler<UpdateExpenseCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = await repository.FirstOrDefaultAsync(new GetExpenseByIdSpec(request.Id), cancellationToken);
        if (expense is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(ExpenseMessageKeys.ExpenseNotFound));
        }
        var updatedexpense = mapper.Map(request.ExpenseDto, expense);
        await repository.UpdateAsync(updatedexpense, cancellationToken);
        return Result.Success(updatedexpense.Id);
    }
}