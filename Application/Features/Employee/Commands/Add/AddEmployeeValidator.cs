using Application.Features.Employee.Commands.Add;
using FluentValidation;

namespace Application.Features.Employee.Commands.Add;

public class AddEmployeeValidator : AbstractValidator<AddEmployeeCommand>
{
    public AddEmployeeValidator()
    {


    }
}