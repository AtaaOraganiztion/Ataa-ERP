using FluentValidation;

namespace Application.Features.Employee.Commands.Delete;

public class DeleteEmployeeValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("EmployeeId is required.");
    }
}