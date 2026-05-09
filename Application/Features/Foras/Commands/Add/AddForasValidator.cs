using FluentValidation;

namespace Application.Features.Foras.Commands.Add;

public class AddForasValidator : AbstractValidator<AddForasCommand>
{
    public AddForasValidator()
    {
        RuleFor(x => x.Title).MaximumLength(200);
    }
}
