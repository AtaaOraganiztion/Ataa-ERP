
using Domain.Entities.Enums;

namespace Application.Features.Employee.Dtos;

public record EmployeeFilter(
    string? FirstName,
    string? LastName,
    string? Email,
    string? Phone,
    Ulid? SectorId,
    string? jobTitle,
    decimal? Salary,
    DateTime? HireDate,
    EmploymentType? EmploymentType,
    EmployeeStatus? Status,
    string? Location
    );