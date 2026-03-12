using Application.Features.Employee.Commands.Add;
using FluentValidation;
using SharedKernel;

namespace Application.Features.Salary.Commands.Add;

public class AddSalaryValidator : AbstractValidator<AddSalaryCommand>
{
    public AddSalaryValidator()
    {
        RuleFor(x => x.EmployeeId).NotEmpty();
        RuleFor(x => x.BaseSalary).NotEmpty();


    }
}