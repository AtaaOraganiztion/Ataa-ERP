using Application.Abstractions.Messaging;

namespace Application.Features.Salary.Commands.Delete;

public record DeleteSalaryCommand(Ulid Id) : ICommand<Ulid>;