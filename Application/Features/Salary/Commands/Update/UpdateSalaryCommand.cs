using Application.Abstractions.Messaging;
using Application.Features.Salary.Dtos;

namespace Application.Features.Salary.Commands.Update;

public record UpdateSalaryCommand(Ulid Id, UpdateSalaryDto? SalaryDto) : ICommand<Ulid>;