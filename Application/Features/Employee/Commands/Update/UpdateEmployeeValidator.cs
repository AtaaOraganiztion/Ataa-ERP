using FluentValidation;

namespace Application.Features.Employee.Commands.Update;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}