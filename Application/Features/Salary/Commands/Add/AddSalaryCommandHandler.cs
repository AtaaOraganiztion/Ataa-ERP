using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using AutoMapper;
using Domain.Email;
using SharedKernel;

namespace Application.Features.Salary.Commands.Add;

public class AddsalaryCommandHand(IMapper mapper, IRepository<Domain.Models.Salary.Salary> repository, IEmailService emailService) : ICommandHandler<AddSalaryCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(AddSalaryCommand request, CancellationToken cancellationToken)
    {
        var employee = mapper.Map<Domain.Models.Salary.Salary>(request);
        await repository.AddAsync(employee, cancellationToken);

        return Result.Success(employee.Id);
    }
}