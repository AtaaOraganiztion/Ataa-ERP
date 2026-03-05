
using Domain.Entities.Enums;


namespace Application.Features.Salary.Dtos
{
    public record UpdateSalaryDto(
    Ulid EmployeeId,
    decimal? BaseSalary,
    decimal? Allowances,
    decimal? Deductions,
    decimal? OvertimeAmount,
    decimal?  BonusAmount,
    decimal? NetSalary,
    decimal? HoursWorked,
    int? Month,
    int? Year,
    bool? IsConfirmed
    );
}
