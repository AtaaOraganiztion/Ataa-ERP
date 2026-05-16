using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.EmployeePerformanceReport.Specifications;
using Domain.Models.CRM.EmployeePerformanceReport;
using SharedKernel;

namespace Application.Features.CRM.EmployeePerformanceReport.Commands.Delete;

public class DeleteEmployeePerformanceReportCommandHandler(
    IRepository<Domain.Models.CRM.EmployeePerformanceReport.EmployeePerformanceReport> repository)
    : ICommandHandler<DeleteEmployeePerformanceReportCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteEmployeePerformanceReportCommand request, CancellationToken cancellationToken)
    {
        var spec = new EmployeePerformanceReportByIdSpec(request.Id);
        var report = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        
        if (report is null)
            return Result.Failure<Ulid>(Error.NotFound(EmployeePerformanceReportMessageKeys.EmployeePerformanceReportNotFound));

        await repository.DeleteAsync(report, cancellationToken);
        
        return Result.Success(report.Id);
    }
}
