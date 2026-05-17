using Application.Abstractions.Messaging;
using Application.Features.CRM.EmployeePerformanceReport.Dtos;
using SharedKernel;

namespace Application.Features.CRM.EmployeePerformanceReport.Queries.GetList;

public record GetEmployeePerformanceReportsQuery() : IQuery<List<EmployeePerformanceReportDto>>;
