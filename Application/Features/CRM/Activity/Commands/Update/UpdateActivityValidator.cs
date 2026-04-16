using FluentValidation;

namespace Application.Features.CRM.Activity.Commands.Update;

public class UpdateActivityValidator : AbstractValidator<UpdateActivityCommand>
{
    public UpdateActivityValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Request.Subject).MaximumLength(200).When(x => x.Request.Subject != null);
    }
}