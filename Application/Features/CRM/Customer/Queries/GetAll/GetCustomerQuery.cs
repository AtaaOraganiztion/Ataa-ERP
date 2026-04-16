using Application.Abstractions.Messaging;
using Application.Features.CRM.Customer.Dtos;


namespace Application.Features.Customer.Queries.GetAll;

public record GetCustomerQuery(CustomerFilter CustomerFilter) : IQuery<List<GetCustomerDto>>;