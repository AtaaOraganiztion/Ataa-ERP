using Domain.Entities.Enums;

namespace Application.Features.Employee.Dtos;

public record GetEmployeeDto(
    Ulid Id,
    string? EmployeeFirstName,
    string? EmployeeLastName,
    string? EmployeeEmail,
    string? EmployeeNumber,
    Ulid? SectorId,
    string? SectorName,
    string? JobTitle,
    decimal? BaseSalary,
    DateTime? HireDate,
    EmploymentType? EmploymentType,
    EmployeeStatus? Status,
    string? Location
);