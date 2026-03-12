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
        List<Domain.Models.Salary.Salary> salary = await repository.ListAsync(
            new GetSalarySpec(request.SalaryFilter),
            cancellationToken);

        List<GetSalaryDto> salaryDtos = mapper.Map<List<GetSalaryDto>>(salary);
        return Result.Success(salaryDtos);
    }
}