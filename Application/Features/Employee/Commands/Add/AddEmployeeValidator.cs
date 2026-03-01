using Application.Features.Employee.Commands.Add;
using FluentValidation;

namespace Application.Features.Employee.Commands.Add;

public class AddEmployeeValidator : AbstractValidator<AddEmployeeCommand>
{
    public AddEmployeeValidator()
    {
        RuleFor(x => x.EmployeeEmail).NotEmpty();
        RuleFor(x => x.EmployeeNumber).NotEmpty();


    }
}