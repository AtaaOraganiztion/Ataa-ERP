using FluentValidation;

namespace Application.Features.Finance.Expense.Commands.Update;

public class UpdateExpenseValidator : AbstractValidator<UpdateExpenseCommand>
{
    public UpdateExpenseValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}