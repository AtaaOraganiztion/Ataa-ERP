using Application.Features.Finance.Budget.Commands.Add;
using FluentValidation;

namespace Application.Features.Finance.Budget.Commands.Add;

public class AddBudgetValidator : AbstractValidator<AddBudgetCommand>
{
    public AddBudgetValidator()
    {
        RuleFor(x => x.ConfirmedBy).NotEmpty();
        RuleFor(x => x.IsConfirmed).NotEmpty();


    }
}
