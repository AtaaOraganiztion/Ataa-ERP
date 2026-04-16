using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Customer.Dtos;
using Application.Features.CRM.Customer.Specifications;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Customer.Queries.GetAll;

public class GetCustomerQueryHandler(IRepository<Domain.Models.CRM.Customer.Customer> repository, IMapper mapper) : IQueryHandler<GetCustomerQuery, List<GetCustomerDto>>
{
    public async Task<Result<List<GetCustomerDto>>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.CRM.Customer.Customer> Customers = await repository.ListAsync(
            new GetCustomerSpec(request.CustomerFilter),
            cancellationToken);

        List<GetCustomerDto> contactFormDtos = mapper.Map<List<GetCustomerDto>>(Customers);
        return Result.Success(contactFormDtos);
    }
}