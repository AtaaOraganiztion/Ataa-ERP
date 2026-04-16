using FluentValidation;

namespace Application.Features.CRM.Deal.Queries.GetById;

public class GetDealByIdQueryValidator : AbstractValidator<GetDealByIdQuery>
{
    public GetDealByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}