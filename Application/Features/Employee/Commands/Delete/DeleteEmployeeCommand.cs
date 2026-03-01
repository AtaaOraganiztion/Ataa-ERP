using Application.Abstractions.Messaging;

namespace Application.Features.Employee.Commands.Delete;

public record DeleteEmployeeCommand(Ulid Id) : ICommand<Ulid>;