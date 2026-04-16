using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain;
using Domain.Models.CRM.Customer;
using SharedKernel;


namespace Application.Features.CRM.Customer.Commands.Delete;

public class DeleteCustomerCommandHandler(
    IRepository<Domain.Models.CRM.Customer.Customer> repository)
    : ICommandHandler<DeleteCustomerCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (customer is null)
            return Result.Failure<Ulid>(Error.NotFound(CustomerMessageKeys.CustomerNotFound));

        await repository.DeleteAsync(customer, cancellationToken);
        return Result.Success(customer.Id);
    }
}