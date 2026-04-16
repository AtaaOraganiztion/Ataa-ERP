using Application.Abstractions.Messaging;
using Application.Features.CRM.Lead.Dtos;
using Application.Features.CRM.Lead.Queries.GetAll;


namespace Application.Features.CRM.Lead.Queries.GetAll;

public record GetLeadQuery(LeadFilter LeadFilter) : IQuery<List<GetLeadDto>>;