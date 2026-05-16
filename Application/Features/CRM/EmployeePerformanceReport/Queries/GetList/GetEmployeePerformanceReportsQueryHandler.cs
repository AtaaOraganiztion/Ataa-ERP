using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.EmployeePerformanceReport.Dtos;
using Application.Features.CRM.EmployeePerformanceReport.Specifications;
using Domain.Models.CRM.EmployeePerformanceReport;
using SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CRM.EmployeePerformanceReport.Queries.GetList;

public class GetEmployeePerformanceReportsQueryHandler(
    IReadRepository<Domain.Models.CRM.EmployeePerformanceReport.EmployeePerformanceReport> repository)
    : IQueryHandler<GetEmployeePerformanceReportsQuery, List<EmployeePerformanceReportDto>>
{
    public async Task<Result<List<EmployeePerformanceReportDto>>> Handle(GetEmployeePerformanceReportsQuery request, CancellationToken cancellationToken)
    {
        var spec = new EmployeePerformanceReportsSpec();
        var reports = await repository.ListAsync(spec, cancellationToken);

        var result = reports.Select(report => new EmployeePerformanceReportDto(
                report.Id,
                report.Associations,
                report.EmployeeName,
                report.ReportDate,
                report.CorrespondenceStats,
                report.Projects,
                report.FollowUpsCount,
                report.ResponsesCount,
                report.KeyResults
            ))
            .ToList();

        return Result.Success(result);
    }
}
