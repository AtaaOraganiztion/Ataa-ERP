using FluentValidation;

namespace Application.Features.Salary.Commands.Delete;

public class DeleteSalaryValidator : AbstractValidator<DeleteSalaryCommand>
{
    public DeleteSalaryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("EmployeeId is required.");
    }
}