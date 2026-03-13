using Application.Features.Finance.Expense.Commands.Add;
using FluentValidation;

namespace Application.Features.Finance.Commands.Add;

public class AddExpenseValidator : AbstractValidator<AddExpenseCommand>
{
    public AddExpenseValidator()
    {
        RuleFor(x => x.ApprovedBy).NotEmpty();
        RuleFor(x => x.ConfirmedBy).NotEmpty();


    }
}