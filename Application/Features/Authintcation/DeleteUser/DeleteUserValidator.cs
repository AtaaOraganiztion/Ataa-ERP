using FluentValidation;

namespace Application.Features.Employee.Commands.Delete;

public class DeleteUserValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteUserValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("EmployeeId is required.");
    }
}