using FluentValidation;

namespace Application.Features.CRM.Lead.Queries.GetById;

public class GetLeadByIdQueryValidator : AbstractValidator<GetLeadByIdQuery>
{
    public GetLeadByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
