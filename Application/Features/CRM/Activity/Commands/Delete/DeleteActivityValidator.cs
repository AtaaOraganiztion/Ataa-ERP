using FluentValidation;

namespace Application.Features.CRM.Activity.Commands.Delete;

public class DeleteActivityValidator : AbstractValidator<DeleteActivityCommand>
{
    public DeleteActivityValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}