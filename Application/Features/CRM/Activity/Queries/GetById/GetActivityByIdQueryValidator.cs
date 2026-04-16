using FluentValidation;

namespace Application.Features.CRM.Activity.Queries.GetById;

public class GetActivityByIdQueryValidator : AbstractValidator<GetActivityByIdQuery>
{
    public GetActivityByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}