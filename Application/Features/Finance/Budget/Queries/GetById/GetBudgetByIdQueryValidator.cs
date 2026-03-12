using FluentValidation;

namespace Application.Features.Budget.Queries.GetById;

public class GetBudgetByIdQueryValidator : AbstractValidator<GetBudgetByIdQuery>
{
    public GetBudgetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }

}