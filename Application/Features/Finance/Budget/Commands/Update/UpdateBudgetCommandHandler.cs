using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Budget.Specifications;
using AutoMapper;
using Domain.Models.Finance.Budget;

using SharedKernel;

namespace Application.Features.Budget.Commands.Update;

public class UpdateBudgetCommandHandler(IMapper mapper, IRepository<Domain.Models.Finance.Budget.Budget> repository) : ICommandHandler<UpdateBudgetCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateBudgetCommand request, CancellationToken cancellationToken)
    {
        var budget = await repository.FirstOrDefaultAsync(new BudgetByIdSpec(request.Id), cancellationToken);
        if (budget is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(BudgetMessageKeys.BudgetNotFound));
        }
        var updatedBudget = mapper.Map(request.BudgetDto, budget);
        await repository.UpdateAsync(updatedBudget, cancellationToken);
        return Result.Success(updatedBudget.Id);
    }
}