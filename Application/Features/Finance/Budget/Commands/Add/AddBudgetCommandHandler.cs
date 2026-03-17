using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Features.finance.Budget.Commands.Add;
using AutoMapper;
using Domain.Email;
using SharedKernel;

namespace Application.Features.finance.Budget.Commands.Add;

public class AddBudgetCommandHandler(IMapper mapper, IRepository<Domain.Models.Finance.Budget.Budget> repository, IEmailService emailService) : ICommandHandler<AddBudgetCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(AddBudgetCommand request, CancellationToken cancellationToken)
    {
        var budget = mapper.Map<Domain.Models.Finance.Budget.Budget>(request);
        await repository.AddAsync(budget, cancellationToken);

        return Result.Success(budget.Id);
    }
}