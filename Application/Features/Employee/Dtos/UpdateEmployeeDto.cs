
using Domain.Entities.Enums;

namespace Application.Features.Employee.Dtos;

public record UpdateEmployeeDto(
    string? EmployeeFirstName,
    string? EmployeeLastName,
    string? EmployeeEmail,
    string? EmployeeNumber,
    Ulid? SectorId,
    string? JobTitle,
    decimal? BaseSalary,
    DateTime? HireDate,
    EmploymentType? EmploymentType,
    EmployeeStatus? Status,
    string? Location
    );