using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.EmployeePerformanceReport.Specifications;
using Domain.Models.CRM.EmployeePerformanceReport;
using SharedKernel;

namespace Application.Features.CRM.EmployeePerformanceReport.Commands.Update;

public class UpdateEmployeePerformanceReportCommandHandler(
    IRepository<Domain.Models.CRM.EmployeePerformanceReport.EmployeePerformanceReport> repository)
    : ICommandHandler<UpdateEmployeePerformanceReportCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateEmployeePerformanceReportCommand command, CancellationToken cancellationToken)
    {
        var spec = new EmployeePerformanceReportByIdSpec(command.Id);
        var report = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        
        if (report is null)
            return Result.Failure<Ulid>(Error.NotFound(EmployeePerformanceReportMessageKeys.EmployeePerformanceReportNotFound));

        report.Associations = command.Request.Associations;
        report.EmployeeName = command.Request.EmployeeName;
        report.ReportDate = command.Request.ReportDate;
        report.CorrespondenceStats = command.Request.CorrespondenceStats;
        report.Projects = command.Request.Projects;
        report.FollowUpsCount = command.Request.FollowUpsCount;
        report.ResponsesCount = command.Request.ResponsesCount;
        report.KeyResults = command.Request.KeyResults;

        await repository.UpdateAsync(report, cancellationToken);
        
        return Result.Success(report.Id);
    }
}
