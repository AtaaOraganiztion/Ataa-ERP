using FluentValidation;

namespace Application.Features.Foras.Queries.GetById;

public class GetForasByIdQueryValidator : AbstractValidator<GetForasByIdQuery>
{
    public GetForasByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
