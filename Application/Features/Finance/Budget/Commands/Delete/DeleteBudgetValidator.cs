using FluentValidation;

namespace Application.Features.Budget.Commands.Delete;

public class DeleteBudgetValidator : AbstractValidator<DeleteBudgetCommand>
{
    public DeleteBudgetValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("BudgetId is required.");
    }
}