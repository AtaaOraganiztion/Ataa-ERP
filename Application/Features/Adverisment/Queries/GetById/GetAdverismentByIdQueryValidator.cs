using FluentValidation;

namespace Application.Features.Adverisment.Queries.GetById;

public class GetAdverismentByIdQueryValidator : AbstractValidator<GetAdverismentByIdQuery>
{
    public GetAdverismentByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}