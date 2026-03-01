using Application.Abstractions.Messaging;
using Application.Features.Employee.Dtos;

namespace Application.Features.Employee.Commands.Update;

public record UpdateEmployeeCommand(Ulid Id, UpdateEmployeeDto? EmployeeDto) : ICommand<Ulid>;
