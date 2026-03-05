using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Salary.Specifications;
using Domain.Models.Salary;
using Domain;
using SharedKernel;

namespace Application.Features.Salary.Commands.Delete;

public class DeleteSalaryCommandHandler(IRepository<Domain.Models.Salary.Salary> repository) : ICommandHandler<DeleteSalaryCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteSalaryCommand request, CancellationToken cancellationToken)
    {
        var employee = await repository.FirstOrDefaultAsync(new SalaryByIdSpec(request.Id), cancellationToken);
        if (employee is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(SalaryMessageKeys.SalaryNotFound));
        }

        await repository.DeleteAsync(employee, cancellationToken);
        return Result.Success(employee.Id);
    }
}