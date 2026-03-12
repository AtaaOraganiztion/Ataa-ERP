using Application.Abstractions.Messaging;
using Application.Features.Salary.Dtos;

namespace Application.Features.Salary.Commands.Update;

<<<<<<< HEAD
public record UpdateSalaryCommand(Ulid Id, UpdateSalaryDto? SalaryDto) : ICommand<Ulid>;
=======
public record UpdateSalaryCommand(Ulid Id, UpdateSalaryDto? SalaryDto) : ICommand<Ulid>;
>>>>>>> 77a4b9b80bb4b9af37d4634bd1e93b7c284163be
