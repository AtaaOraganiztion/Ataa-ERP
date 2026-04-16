using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using Domain.Models.CRM.Customer;
using SharedKernel;

namespace Application.Features.CRM.Customer.Commands.Update;

public class UpdateCustomerCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.CRM.Customer.Customer> repository)
    : ICommandHandler<UpdateCustomerCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (customer is null)
            return Result.Failure<Ulid>(Error.NotFound(CustomerMessageKeys.CustomerNotFound));

        mapper.Map(request.Request, customer);
        await repository.UpdateAsync(customer, cancellationToken);
        return Result.Success(customer.Id);
    }
}