using FluentValidation;

namespace Application.Features.Finance.Expense.Queries.GetById;

public class GetExpenseByIdQueryValidator : AbstractValidator<GetExpenseByIdQuery>
{
    public GetExpenseByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }

}