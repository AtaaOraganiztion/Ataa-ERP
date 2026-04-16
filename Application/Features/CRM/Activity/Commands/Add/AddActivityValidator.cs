using FluentValidation;

namespace Application.Features.CRM.Activity.Commands.Add;

public class AddActivityValidator : AbstractValidator<AddActivityCommand>
{
    public AddActivityValidator()
    {
        RuleFor(x => x.Subject).MaximumLength(200);
        RuleFor(x => x.ActivityDate).NotEmpty();
    }
}