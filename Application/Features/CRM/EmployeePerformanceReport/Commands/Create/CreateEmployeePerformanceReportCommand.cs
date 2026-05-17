using Application.Abstractions.Messaging;
using SharedKernel;

namespace Application.Features.CRM.EmployeePerformanceReport.Commands.Create;

public record CreateEmployeePerformanceReportCommand(
    List<string> Associations,
    string EmployeeName,
    string ReportDate,
    Dictionary<string, int> CorrespondenceStats,
    List<string> Projects,
    int FollowUpsCount,
    int ResponsesCount,
    List<string> KeyResults
) : ICommand<Ulid>;
