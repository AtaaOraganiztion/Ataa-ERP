using FluentValidation;

namespace Application.Features.CRM.Lead.Commands.Delete;

public class DeleteLeadValidator : AbstractValidator<DeleteLeadCommand>
{
    public DeleteLeadValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}