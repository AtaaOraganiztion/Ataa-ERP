using FluentValidation;

namespace Application.Features.Sector.Commands.Update;

public class UpdateSectorValidator : AbstractValidator<UpdateSectorCommand>
{
    public UpdateSectorValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}