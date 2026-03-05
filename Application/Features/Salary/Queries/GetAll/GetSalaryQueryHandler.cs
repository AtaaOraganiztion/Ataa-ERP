using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Salary.Dtos;
using Application.Features.Salary.Specifications;

using AutoMapper;
using SharedKernel;

namespace Application.Features.Salary.Queries.GetAll;

public class GetSalaryQueryHandler(IRepository<Domain.Models.Salary.Salary> repository, IMapper mapper) : IQueryHandler<GetSalaryQuery, List<GetSalaryDto>>
{
    public async Task<Result<List<GetSalaryDto>>> Handle(GetSalaryQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.Salary.Salary> employees = await repository.ListAsync(
            new GetSalarySpec(request.SalaryFilter),
            cancellationToken);

        List<GetSalaryDto> contactFormDtos = mapper.Map<List<GetSalaryDto>>(employees);
        return Result.Success(contactFormDtos);
    }
}