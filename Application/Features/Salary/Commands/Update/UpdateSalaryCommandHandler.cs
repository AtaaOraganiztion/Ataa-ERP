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
        var salary = await repository.FirstOrDefaultAsync(new SalaryByIdSpec(request.Id), cancellationToken);
        if (salary is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(SalaryMessageKeys.SalaryNotFound));
        }
        var updatedsalary = mapper.Map(request.SalaryDto, salary);
        await repository.UpdateAsync(updatedsalary, cancellationToken);
        return Result.Success(updatedsalary.Id);
    }
}