using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Customer.Dtos;
using Application.Features.CRM.Customer.Queries.GetById;
using Application.Features.CRM.Customer.Specifications;
using AutoMapper;
using Domain.Models.CRM.Customer;
using SharedKernel;

namespace Application.Features.CRM.Customer.Queries.GetById;

public class GetCustomerByIdQueryHandler(IRepository<Domain.Models.CRM.Customer.Customer> repository, IMapper mapper) : IQueryHandler<GetCustomerByIdQuery, GetCustomerDto>
{
    public async Task<Result<GetCustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.CRM.Customer.Customer? customer = await repository.FirstOrDefaultAsync(new CustomerByIdSpec(request.Id), cancellationToken);
        if (customer is null)
        {
            return Result.Failure<GetCustomerDto>(Error.NotFound(CustomerMessageKeys.CustomerNotFound));
        }
        GetCustomerDto CustomerDto = mapper.Map<GetCustomerDto>(customer);
        return Result.Success(CustomerDto);
    }
}