using Application.Abstractions.Messaging;
using Domain.Entities.Enums;

namespace Application.Features.Employee.Commands.Add;

public record AddEmployeeCommand( 
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    Ulid? SectorId,
    string jobTitle,
    decimal Salary,
    DateTime HireDate,
    EmploymentType EmploymentType,
    EmployeeStatus Status,
    string Location
    ) : ICommand<Ulid>;