using FluentValidation;

namespace Application.Features.CRM.Lead.Commands.Add;

public class AddLeadValidator : AbstractValidator<AddLeadCommand>
{
    public AddLeadValidator()
    {
        RuleFor(x => x.Title).MaximumLength(200);
        RuleFor(x => x.Value).GreaterThanOrEqualTo(0).When(x => x.Value.HasValue);
    }
}