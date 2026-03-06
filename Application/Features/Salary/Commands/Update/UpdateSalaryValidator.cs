using FluentValidation;

namespace Application.Features.Salary.Commands.Update;

public class UpdateSalaryValidator : AbstractValidator<UpdateSalaryCommand>
{
    public UpdateSalaryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}