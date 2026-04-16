using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.CRM.Deal.Dtos;
using Application.Features.Employee.Dtos;
using Application.Features.Employee.Queries.GetAll;
using Application.Features.Employee.Queries.GetById;
using Application.Features.Employee.Specifications;
using AutoMapper;
using Domain.Models.Employee;
using SharedKernel;
using Domain.Models.CRM.Deal;

namespace Application.Features.CRM.Deal.Queries.GetById;

public class GetDealByIdQueryHandler(IRepository<Domain.Models.CRM.Deal.Deal> repository, IMapper mapper) : IQueryHandler<GetDealByIdQuery, GetDealDto>
{
    public async Task<Result<GetDealDto>> Handle(GetDealByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.CRM.Deal.Deal? deal = await repository.FirstOrDefaultAsync(new DealByIdSpec(request.Id), cancellationToken);
        if (deal is null)
        {
            return Result.Failure<GetDealDto>(Error.NotFound(DealMessageKeys.DealNotFound));
        }
        GetDealDto dealDto = mapper.Map<GetDealDto>(deal);
        return Result.Success(dealDto);
    }
}