using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using AutoMapper;
using Domain.Email;
using SharedKernel;

namespace Application.Features.Finance.Expense.Commands.Add;

public class AddExpenseCommandHandler(IMapper mapper, IRepository<Domain.Models.Finance.Expense.Expense> repository, IEmailService emailService) : ICommandHandler<AddExpenseCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = mapper.Map<Domain.Models.Finance.Expense.Expense>(request);
        await repository.AddAsync(expense, cancellationToken);

        return Result.Success(expense.Id);
    }
}