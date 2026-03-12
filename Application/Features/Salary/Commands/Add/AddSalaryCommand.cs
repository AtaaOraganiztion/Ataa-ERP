using Application.Abstractions.Messaging;
using Domain.Entities.Enums;
using SharedKernel;

namespace Application.Features.Salary.Commands.Add;

public record AddSalaryCommand(
    Ulid EmployeeId,
    decimal BaseSalary,
    decimal Allowances,
    decimal Deductions,
    decimal OvertimeAmount,
    decimal BonusAmount,
    decimal NetSalary,
    decimal HoursWorked,
    int Month,
    int Year,
    bool IsConfirmed
    ) : ICommand<Ulid>;