using FluentValidation;

namespace Application.Features.Adverisment.Commands.Add;

public class AddAdverismentValidator : AbstractValidator<AddAdverismentCommand>
{
    public AddAdverismentValidator()
    {
        RuleFor(x => x.Title).MaximumLength(200);
 
    }
}