using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Finance.Expense.Dtos;
using Application.Features.Finance.Expense.Specifications;

using AutoMapper;
using SharedKernel;

namespace Application.Features.Finance.Expense.Queries.GetAll;

public class GetExpenseQueryHandler(IRepository<Domain.Models.Finance.Expense.Expense> repository, IMapper mapper) : IQueryHandler<GetExpenseQuery, List<GetExpenseDto>>
{
    public async Task<Result<List<GetExpenseDto>>> Handle(GetExpenseQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.Finance.Expense.Expense> expenses = await repository.ListAsync(
            new GetExpenseSpec(request.ExpenseFilter),
            cancellationToken);

        List<GetExpenseDto> contactFormDtos = mapper.Map<List<GetExpenseDto>>(expenses);
        return Result.Success(contactFormDtos);
    }
}