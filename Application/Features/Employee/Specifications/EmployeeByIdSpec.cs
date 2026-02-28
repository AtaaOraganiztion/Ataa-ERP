using Ardalis.Specification;

namespace Application.Features.Employee.Specifications;

public class EmployeeByIdSpec : Specification<Domain.Models.Employee.Employee>
{
    public EmployeeByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}