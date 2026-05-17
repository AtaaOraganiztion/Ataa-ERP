using Ardalis.Specification;
using Domain.Entities.Enums;
using Domain.Models.Employee;

namespace Application.Features.Employee.Specifications;

public class ActiveEmployeesSpec : Specification<Domain.Models.Employee.Employee>
{
    public ActiveEmployeesSpec()
    {
        Query.Where(e => e.Status == EmployeeStatus.Active);
    }
}
