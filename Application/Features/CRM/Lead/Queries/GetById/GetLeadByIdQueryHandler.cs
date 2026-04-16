using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Lead.Dtos;
using Application.Features.Employee.Dtos;
using Application.Features.Employee.Queries.GetById;
using Application.Features.Employee.Specifications;
using AutoMapper;
using Domain.Models.CRM.Lead;
using Domain.Models.Employee;
using SharedKernel;

namespace Application.Features.CRM.Lead.Queries.GetById;

public class GetLeadByIdQueryHandler(IRepository<Domain.Models.CRM.Lead.Lead> repository, IMapper mapper) : IQueryHandler<GetLeadByIdQuery, GetLeadDto>
{
    public async Task<Result<GetLeadDto>> Handle(GetLeadByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.CRM.Lead.Lead? lead = await repository.FirstOrDefaultAsync(new LeadByIdSpec(request.Id), cancellationToken);
        if (lead is null)
        {
            return Result.Failure<GetLeadDto>(Error.NotFound(LeadMessageKeys.LeadNotFound));
        }
        GetLeadDto leadDto = mapper.Map<GetLeadDto>(lead);
        return Result.Success(leadDto);
    }
}