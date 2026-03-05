using Ardalis.Specification;

namespace Application.Features.Salary.Specifications;

public class SalaryByIdSpec : Specification<Domain.Models.Salary.Salary>
{
    public SalaryByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}