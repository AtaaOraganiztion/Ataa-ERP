using Domain.Entities.Enums;
using SharedKernel;

namespace Application.Features.Salary.Dtos;

public record GetSalaryDto(
    Ulid Id,
    Ulid? EmployeeId,
    decimal? BaseSalary,
    decimal? Allowances,
    decimal? Deductions,
    decimal? OvertimeAmount,
    decimal? BonusAmount,
    decimal? NetSalary,
    decimal? HoursWorked,
    int? Month,
    int? Year,
    bool? IsConfirmed
    );