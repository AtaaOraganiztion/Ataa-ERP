using Application.Abstractions.Messaging;
using Application.Features.CRM.Lead.Dtos;
using Application.Features.Employee.Dtos;

namespace Application.Features.CRM.Lead.Queries.GetById;

public record GetLeadByIdQuery(Ulid Id) : IQuery<GetLeadDto>;
