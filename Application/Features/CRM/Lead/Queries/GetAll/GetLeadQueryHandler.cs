using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Lead.Dtos;
using Application.Features.CRM.Lead.Specifications;
using Application.Features.Employee.Dtos;
using Application.Features.Employee.Queries.GetAll;
using Application.Features.Employee.Specifications;
using AutoMapper;
using SharedKernel;

namespace Application.Features.CRM.Lead.Queries.GetAll;

public class GetLeadQueryHandler(IRepository<Domain.Models.CRM.Lead.Lead> repository, IMapper mapper) : IQueryHandler<GetLeadQuery, List<GetLeadDto>>
{
    public async Task<Result<List<GetLeadDto>>> Handle(GetLeadQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.CRM.Lead.Lead> leads = await repository.ListAsync(
            new GetLeadSpec(request.LeadFilter),
            cancellationToken);

        List<GetLeadDto> contactFormDtos = mapper.Map<List<GetLeadDto>>(leads);
        return Result.Success(contactFormDtos);
    }
}