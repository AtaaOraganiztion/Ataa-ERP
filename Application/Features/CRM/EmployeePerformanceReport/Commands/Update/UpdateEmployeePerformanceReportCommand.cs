using Application.Abstractions.Messaging;
using Application.Features.CRM.EmployeePerformanceReport.Dtos;
using SharedKernel;

namespace Application.Features.CRM.EmployeePerformanceReport.Commands.Update;

public record UpdateEmployeePerformanceReportCommand(Ulid Id, UpdateEmployeePerformanceReportDto Request) : ICommand<Ulid>;
