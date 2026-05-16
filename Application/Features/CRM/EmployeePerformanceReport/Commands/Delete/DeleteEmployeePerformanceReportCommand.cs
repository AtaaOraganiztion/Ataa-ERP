using Application.Abstractions.Messaging;
using SharedKernel;

namespace Application.Features.CRM.EmployeePerformanceReport.Commands.Delete;

public record DeleteEmployeePerformanceReportCommand(Ulid Id) : ICommand<Ulid>;
