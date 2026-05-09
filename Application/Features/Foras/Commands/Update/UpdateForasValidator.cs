using FluentValidation;

namespace Application.Features.Foras.Commands.Update;

public class UpdateForasValidator : AbstractValidator<UpdateForasCommand>
{
    public UpdateForasValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Request.Title).MaximumLength(200).When(x => x.Request.Title != null);
    }
}
