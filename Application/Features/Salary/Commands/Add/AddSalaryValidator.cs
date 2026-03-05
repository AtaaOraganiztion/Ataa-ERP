using Application.Features.Employee.Commands.Add;
using FluentValidation;

namespace Application.Features.Salary.Commands.Add;

public class AddSalaryValidator : AbstractValidator<AddSalaryCommand>
{
    public AddSalaryValidator()
    {
        RuleFor(x => x.BaseSalary).NotEmpty();
        RuleFor(x => x.IsConfirmed).NotEmpty();


    }
}