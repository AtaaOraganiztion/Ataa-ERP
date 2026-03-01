using Application.Features.Sector.Commands.Add;
using FluentValidation;

namespace Application.Features.Sector.Commands.Add;

public class AddSectorValidator : AbstractValidator<AddSectorCommand>
{
    public AddSectorValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Sector name is required.")
            .MaximumLength(200).WithMessage("Sector name must be at most 200 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description must be at most 1000 characters.")
            .When(x => x.Description != null);
    }
}