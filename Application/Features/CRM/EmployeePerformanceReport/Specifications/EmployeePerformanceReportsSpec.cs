using Ardalis.Specification;
using Domain.Models.CRM.EmployeePerformanceReport;

namespace Application.Features.CRM.EmployeePerformanceReport.Specifications;

public class EmployeePerformanceReportsSpec : Specification<Domain.Models.CRM.EmployeePerformanceReport.EmployeePerformanceReport>
{
    public EmployeePerformanceReportsSpec()
    {
        Query.OrderByDescending(x => x.Id); // Default ordering
    }
}
