using FluentValidation;

namespace Application.Features.Finance.Expense.Commands.Delete;

public class DeleteExpenseValidator : AbstractValidator<DeleteExpenseCommand>
{
    public DeleteExpenseValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ExpenseId is required.");
    }
}