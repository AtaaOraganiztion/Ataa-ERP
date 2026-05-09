using FluentValidation;

namespace Application.Features.CRM.GlobalActivity.Commands.Add;

public class AddGlobalActivityValidator : AbstractValidator<AddGlobalActivityCommand>
{
    public AddGlobalActivityValidator()
    {
        RuleFor(x => x.Subject).NotEmpty().MaximumLength(200);
        RuleFor(x => x.ActivityDate).NotEmpty();
    }
}
