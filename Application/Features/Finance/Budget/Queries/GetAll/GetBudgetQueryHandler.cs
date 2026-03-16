using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.finance.Budget.Dtos;
using Application.Features.finance.Budget.Specifications;
using AutoMapper;
using SharedKernel;

namespace Application.Features.finance.Budget.Queries.GetAll;

public class GetBudgetQueryHandler(IRepository<Domain.Models.Finance.Budget.Budget> repository, IMapper mapper) : IQueryHandler<GetBudgetQuery, List<GetBudgetDto>>
{
    public async Task<Result<List<GetBudgetDto>>> Handle(GetBudgetQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.Finance.Budget.Budget> budgets = await repository.ListAsync(
            new GetBudgetSpec(request.BudgetFilter),
            cancellationToken);

        List<GetBudgetDto> contactFormDtos = mapper.Map<List<GetBudgetDto>>(budgets);
        return Result.Success(contactFormDtos);
    }
}