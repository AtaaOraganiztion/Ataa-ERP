using FluentValidation;

namespace Application.Features.Sector.Commands.Delete;

public class DeleteSectorValidator : AbstractValidator<DeleteSectorCommand>
{
    public DeleteSectorValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SectorId is required.");
    }
}