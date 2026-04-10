using Application.Features.Finance.Budget.Queries.GetById;
using FluentValidation;

namespace Application.Features.Finance.Budget.Queries.GetById;

public class GetBudgetByIdQueryValidator : AbstractValidator<GetBudgetByIdQuery>
{
    public GetBudgetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }

}
