using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using AutoMapper;
using Domain.Email;
using SharedKernel;

namespace Application.Features.Salary.Commands.Add;

public class AddsalaryCommandHand(IMapper mapper, IRepository<Domain.Models.Salary.Salary> repository, IRepository<Domain.Models.Employee.Employee> employeeRepository, IEmailService emailService) : ICommandHandler<AddSalaryCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(AddSalaryCommand request, CancellationToken cancellationToken)
    {
        // verify the employee exists to avoid FK constraint violation
        var employeeEntity = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
        if (employeeEntity is null)
            return Result.Failure<Ulid>(Error.NotFound("Employee.NotFound"));

        var salary = mapper.Map<Domain.Models.Salary.Salary>(request);
        // ensure the EmployeeId is set (AutoMapper maps it but keep explicit assignment to be safe)
        salary.EmployeeId = request.EmployeeId;

        await repository.AddAsync(salary, cancellationToken);

        return Result.Success(salary.Id);
    }
}