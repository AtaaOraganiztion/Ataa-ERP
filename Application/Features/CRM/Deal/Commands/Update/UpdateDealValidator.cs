using FluentValidation;

namespace Application.Features.CRM.Deal.Commands.Update;

public class UpdateDealValidator : AbstractValidator<UpdateDealCommand>
{
    public UpdateDealValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Request.Title).MaximumLength(200).When(x => x.Request.Title != null);
        RuleFor(x => x.Request.Value).GreaterThanOrEqualTo(0).When(x => x.Request.Value.HasValue);
    }
}