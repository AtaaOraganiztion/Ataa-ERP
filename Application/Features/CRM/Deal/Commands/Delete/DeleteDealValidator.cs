using FluentValidation;

namespace Application.Features.CRM.Deal.Commands.Delete;

public class DeleteDealValidator : AbstractValidator<DeleteDealCommand>
{
    public DeleteDealValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}