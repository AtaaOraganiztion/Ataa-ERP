using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Finance.Expense.Dtos;
using Application.Features.Finance.Expense.Specifications;
using AutoMapper;
using Domain.Models.Finance.Expense;
using SharedKernel;

namespace Application.Features.Finance.Expense.Queries.GetById;

public class GetExpenseByIdQueryHandler(IRepository<Domain.Models.Finance.Expense.Expense> repository, IMapper mapper) : IQueryHandler<GetExpenseByIdQuery, GetExpenseDto>
{
    public async Task<Result<GetExpenseDto>> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.Finance.Expense.Expense? expense = await repository.FirstOrDefaultAsync(new GetExpenseByIdSpec(request.Id), cancellationToken);
        if (expense is null)
        {
            return Result.Failure<GetExpenseDto>(Error.NotFound(ExpenseMessageKeys.ExpenseNotFound));
        }
        GetExpenseDto expenseDto = mapper.Map<GetExpenseDto>(expense);
        return Result.Success(expenseDto);
    }
}