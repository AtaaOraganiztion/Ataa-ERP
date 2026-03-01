using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Employee.Specifications;
using Domain.Models.Employee;
using SharedKernel;

namespace Application.Features.Employee.Commands.Delete;

public class DeleteEmployeeCommandHandler(IRepository<Domain.Models.Employee.Employee> repository) : ICommandHandler<DeleteEmployeeCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.FirstOrDefaultAsync(new EmployeeByIdSpec(request.Id),cancellationToken);
        if (employee is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(EmployeeMessageKeys.EmployeeNotFound));
        }

        await repository.DeleteAsync(employee, cancellationToken);
        return Result.Success(employee.Id);
    }
}