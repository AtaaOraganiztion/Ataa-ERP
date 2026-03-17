using Application.Features.Budget.Commands.Add;
using FluentValidation;

namespace Application.Features.finance.Budget.Commands.Add;

public class AddBudgetValidator : AbstractValidator<AddBudgetCommand>
{
    public AddBudgetValidator()
    {
        RuleFor(x => x.ConfirmedBy).NotEmpty();
        RuleFor(x => x.IsConfirmed).NotEmpty();


    }
}