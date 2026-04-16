using FluentValidation;

namespace Application.Features.CRM.Deal.Commands.Add;

public class AddDealValidator : AbstractValidator<AddDealCommand>
{
    public AddDealValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.LeadId).NotEmpty();
        RuleFor(x => x.Value).GreaterThanOrEqualTo(0);
    }
}