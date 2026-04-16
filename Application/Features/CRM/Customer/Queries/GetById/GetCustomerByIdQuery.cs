using Application.Abstractions.Messaging;
using Application.Features.CRM.Customer.Dtos;

namespace Application.Features.CRM.Customer.Queries.GetById;

public record GetCustomerByIdQuery(Ulid Id) : IQuery<GetCustomerDto>;