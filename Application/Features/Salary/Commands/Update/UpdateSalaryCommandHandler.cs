using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Salary.Specifications;
using AutoMapper;
using Domain.Models.Salary;
using SharedKernel;

namespace Application.Features.Salary.Commands.Update;

public class UpdateSalaryCommandHandler(IMapper mapper, IRepository<Domain.Models.Salary.Salary> repository) : ICommandHandler<UpdateSalaryCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateSalaryCommand request, CancellationToken cancellationToken)
    {
<<<<<<< HEAD
        var salary = await repository.FirstOrDefaultAsync(new SalaryByIdSpec(request.Id), cancellationToken);
        if (salary is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(SalaryMessageKeys.SalaryNotFound));
        }
        var updatedsalary = mapper.Map(request.SalaryDto, salary);
        await repository.UpdateAsync(updatedsalary, cancellationToken);
        return Result.Success(updatedsalary.Id);
=======
        var employee = await repository.FirstOrDefaultAsync(new SalaryByIdSpec(request.Id), cancellationToken);
        if (employee is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(SalaryMessageKeys.SalaryNotFound));
        }
        var updatedSalary = mapper.Map(request.SalaryDto, employee);
        await repository.UpdateAsync(updatedSalary, cancellationToken);
        return Result.Success(updatedSalary.Id);
>>>>>>> 77a4b9b80bb4b9af37d4634bd1e93b7c284163be
    }
}