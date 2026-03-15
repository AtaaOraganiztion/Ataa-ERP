using FluentValidation;

namespace Application.Features.finance.Budget.Commands.Update;

public class UpdateBudgetValidator : AbstractValidator<UpdateBudgetCommand>
{
    public UpdateBudgetValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}