using Application.Abstractions.Messaging;
using Application.Features.CRM.EmployeePerformanceReport.Dtos;
using SharedKernel;

namespace Application.Features.CRM.EmployeePerformanceReport.Queries.GetById;

public record GetEmployeePerformanceReportByIdQuery(Ulid Id) : IQuery<EmployeePerformanceReportDto>;
