using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Budget.Dtos;
using Application.Features.Budget.Specifications;
using AutoMapper;
using Domain.Models.Finance.Budget;
using SharedKernel;

namespace Application.Features.Budget.Queries.GetById;

public class GetBudgetByIdQueryHandler(IRepository<Domain.Models.Finance.Budget.Budget> repository, IMapper mapper) : IQueryHandler<GetBudgetByIdQuery, GetBudgetDto>
{
    public async Task<Result<GetBudgetDto>> Handle(GetBudgetByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.Finance.Budget.Budget? budget = await repository.FirstOrDefaultAsync(new BudgetByIdSpec(request.Id), cancellationToken);
        if (budget is null)
        {
            return Result.Failure<GetBudgetDto>(Error.NotFound(BudgetMessageKeys.BudgetNotFound));
        }
        GetBudgetDto budgetDto = mapper.Map<GetBudgetDto>(budget);
        return Result.Success(budgetDto);
    }
}