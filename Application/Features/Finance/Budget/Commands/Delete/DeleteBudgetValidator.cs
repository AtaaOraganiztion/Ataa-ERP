using FluentValidation;

namespace Application.Features.finance.Budget.Commands.Delete;

public class DeleteBudgetValidator : AbstractValidator<DeleteBudgetCommand>
{
    public DeleteBudgetValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("BudgetId is required.");
    }
}