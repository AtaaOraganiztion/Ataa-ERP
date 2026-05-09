using FluentValidation;

namespace Application.Features.Adverisment.Commands.Update;

public class UpdateAdverismentValidator : AbstractValidator<UpdateAdverismentCommand>
{
    public UpdateAdverismentValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Request.Title).MaximumLength(200).When(x => x.Request.Title != null);
    }
}