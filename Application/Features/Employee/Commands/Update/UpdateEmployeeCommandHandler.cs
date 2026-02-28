using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Employee.Specifications;
using AutoMapper;
using Domain.Models.Employee;
using SharedKernel;

namespace Application.Features.Employee.Commands.Update;

public class UpdateEmployeeCommandHandler(IMapper mapper, IRepository<Domain.Models.Employee.Employee> repository) : ICommandHandler<UpdateEmployeeCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.FirstOrDefaultAsync(new EmployeeByIdSpec(request.Id), cancellationToken);
        if (employee is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(EmployeeMessageKeys.EmployeeNotFound));
        }
        var updatedEmployee = mapper.Map(request.EmployeeDto, employee);
        await repository.UpdateAsync(updatedEmployee, cancellationToken);
        return Result.Success(updatedEmployee.Id);
    }
}