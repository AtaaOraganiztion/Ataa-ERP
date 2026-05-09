using FluentValidation;

namespace Application.Features.CRM.GlobalActivity.Commands.Update;

public class UpdateGlobalActivityValidator : AbstractValidator<UpdateGlobalActivityCommand>
{
    public UpdateGlobalActivityValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Request.Subject).MaximumLength(200);
    }
}
