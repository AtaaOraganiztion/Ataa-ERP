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
        var employee = await repository.FirstOrDefaultAsync(new SalaryByIdSpec(request.Id), cancellationToken);
        if (employee is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(SalaryMessageKeys.SalaryNotFound));
        }
        var updatedSalary = mapper.Map(request.SalaryDto, employee);
        await repository.UpdateAsync(updatedSalary, cancellationToken);
        return Result.Success(updatedSalary.Id);
    }
}