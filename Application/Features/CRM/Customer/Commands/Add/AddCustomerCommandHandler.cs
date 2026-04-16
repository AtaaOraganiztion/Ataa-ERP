using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using SharedKernel;

namespace Application.Features.CRM.Customer.Commands.Add;

public class AddCustomerCommandHandler(
    IMapper mapper,
    IRepository<Domain.Models.CRM.Customer.Customer> repository)
    : ICommandHandler<AddCustomerCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = mapper.Map<Domain.Models.CRM.Customer.Customer>(request);
        await repository.AddAsync(customer, cancellationToken);
        return Result.Success(customer.Id);
    }
}