namespace Application.Features.CRM.EmployeePerformanceReport.Dtos;

public record EmployeePerformanceReportDto(
    Ulid Id,
    List<string> Associations,
    string EmployeeName,
    string ReportDate,
    Dictionary<string, int> CorrespondenceStats,
    List<string> Projects,
    int FollowUpsCount,
    int ResponsesCount,
    List<string> KeyResults
);
