using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Models.CRM.EmployeePerformanceReport;
using SharedKernel;

namespace Application.Features.CRM.EmployeePerformanceReport.Commands.Create;

public class CreateEmployeePerformanceReportCommandHandler(
    IRepository<Domain.Models.CRM.EmployeePerformanceReport.EmployeePerformanceReport> repository)
    : ICommandHandler<CreateEmployeePerformanceReportCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(CreateEmployeePerformanceReportCommand request, CancellationToken cancellationToken)
    {
        var report = new Domain.Models.CRM.EmployeePerformanceReport.EmployeePerformanceReport
        {
            Associations = request.Associations,
            EmployeeName = request.EmployeeName,
            ReportDate = request.ReportDate,
            CorrespondenceStats = request.CorrespondenceStats,
            Projects = request.Projects,
            FollowUpsCount = request.FollowUpsCount,
            ResponsesCount = request.ResponsesCount,
            KeyResults = request.KeyResults
        };

        await repository.AddAsync(report, cancellationToken);
        
        return Result.Success(report.Id);
    }
}
