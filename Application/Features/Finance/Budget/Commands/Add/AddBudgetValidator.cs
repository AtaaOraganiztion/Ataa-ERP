using FluentValidation;

namespace Application.Features.Finance.Budget.Commands.Add;

public class AddBudgetValidator : AbstractValidator<AddBudgetCommand>
{
    public AddBudgetValidator()
    {
        RuleFor(x => x.ConfirmedBy)
            .NotEmpty()
            .When(x => x.IsConfirmed == true);

        RuleFor(x => x.ConfirmedDate)
            .NotEmpty()
            .When(x => x.IsConfirmed == true);
    }
}