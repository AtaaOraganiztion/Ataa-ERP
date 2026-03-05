using FluentValidation;

namespace Application.Features.Salary.Queries.GetById;

public class GetSalaryByIdQueryValidator : AbstractValidator<GetSalaryByIdQuery>
{
    public GetSalaryByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }

}