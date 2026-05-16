using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.EmployeePerformanceReport.Dtos;
using Application.Features.CRM.EmployeePerformanceReport.Specifications;
using Domain.Models.CRM.EmployeePerformanceReport;
using SharedKernel;

namespace Application.Features.CRM.EmployeePerformanceReport.Queries.GetById;

public class GetEmployeePerformanceReportByIdQueryHandler(
    IReadRepository<Domain.Models.CRM.EmployeePerformanceReport.EmployeePerformanceReport> repository)
    : IQueryHandler<GetEmployeePerformanceReportByIdQuery, EmployeePerformanceReportDto>
{
    public async Task<Result<EmployeePerformanceReportDto>> Handle(GetEmployeePerformanceReportByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new EmployeePerformanceReportByIdSpec(request.Id);
        var report = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        
        if (report is null)
            return Result.Failure<EmployeePerformanceReportDto>(Error.NotFound(EmployeePerformanceReportMessageKeys.EmployeePerformanceReportNotFound));

        return Result.Success(new EmployeePerformanceReportDto(
            report.Id,
            report.Associations,
            report.EmployeeName,
            report.ReportDate,
            report.CorrespondenceStats,
            report.Projects,
            report.FollowUpsCount,
            report.ResponsesCount,
            report.KeyResults
        ));
    }
}
