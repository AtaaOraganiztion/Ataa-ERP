using FluentValidation;

namespace Application.Features.Sector.Queries.GetById;

public class GetSectorByIdQueryValidator : AbstractValidator<GetSectorByIdQuery>
{
    public GetSectorByIdQueryValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty();
    }
    
}