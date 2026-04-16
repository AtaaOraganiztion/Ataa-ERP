using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Deal.Dtos;
using Application.Features.CRM.Deal.Specifications;
using Application.Features.CRM.Lead.Specifications;
using Application.Features.Employee.Dtos;
using Application.Features.Employee.Queries.GetAll;
using Application.Features.Employee.Specifications;
using AutoMapper;
using SharedKernel;

namespace Application.Features.CRM.Deal.Queries.GetAll;

public class GetDealQueryHandler(IRepository<Domain.Models.CRM.Deal.Deal> repository, IMapper mapper) : IQueryHandler<GetDealQuery, List<GetDealDto>>
{
    public async Task<Result<List<GetDealDto>>> Handle(GetDealQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.CRM.Deal.Deal> deals = await repository.ListAsync(
            new GetDealSpec(request.Filter),
            cancellationToken);

        List<GetDealDto> dealDtos = mapper.Map<List<GetDealDto>>(deals);
        return Result.Success(dealDtos);
    }
}