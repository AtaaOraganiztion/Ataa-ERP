using Ardalis.Specification;
using Domain.Models.CRM.EmployeePerformanceReport;

namespace Application.Features.CRM.EmployeePerformanceReport.Specifications;

public class EmployeePerformanceReportByIdSpec : Specification<Domain.Models.CRM.EmployeePerformanceReport.EmployeePerformanceReport>, ISingleResultSpecification<Domain.Models.CRM.EmployeePerformanceReport.EmployeePerformanceReport>
{
    public EmployeePerformanceReportByIdSpec(Ulid id)
    {
        Query.Where(x => x.Id == id);
    }
}
