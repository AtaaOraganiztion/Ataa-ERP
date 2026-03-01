using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using AutoMapper;
using Domain.Email;
using SharedKernel;

namespace Application.Features.Employee.Commands.Add;

public class AddEmployeeCommandHandler(IMapper mapper, IRepository<Domain.Models.Employee.Employee> repository, IEmailService emailService) : ICommandHandler<AddEmployeeCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = mapper.Map<Domain.Models.Employee.Employee>(request);
        await repository.AddAsync(employee, cancellationToken);
        
        return Result.Success(employee.Id);
    }
}