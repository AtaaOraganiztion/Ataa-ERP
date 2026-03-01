using Application.Abstractions.Messaging;
using Domain.Entities.Enums;

namespace Application.Features.Employee.Commands.Add;

public record AddEmployeeCommand( 
    string EmployeeFirstName,
    string EmployeeLastName,
    string EmployeeEmail,
    string EmployeeNumber,
    Ulid? SectorId,
    string JobTitle,
    decimal BaseSalary,
    DateTime HireDate,
    EmploymentType EmploymentType,
    EmployeeStatus Status,
    string Location
    ) : ICommand<Ulid>;