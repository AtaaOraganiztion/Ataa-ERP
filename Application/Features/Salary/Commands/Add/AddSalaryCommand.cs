using Application.Abstractions.Messaging;
using Domain.Entities.Enums;

namespace Application.Features.Salary.Commands.Add;

public record AddSalaryCommand(
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