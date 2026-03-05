using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Salary.Dtos;
using Application.Features.Salary.Specifications;
using Domain.Models.Salary;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Salary.Queries.GetById;

public class GetSalaryByIdQueryHandler(IRepository<Domain.Models.Salary.Salary> repository, IMapper mapper) : IQueryHandler<GetSalaryByIdQuery, GetSalaryDto>
{
    public async Task<Result<GetSalaryDto>> Handle(GetSalaryByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.Salary.Salary? salary = await repository.FirstOrDefaultAsync(new SalaryByIdSpec(request.Id), cancellationToken);
        if (salary is null)
        {
            return Result.Failure<GetSalaryDto>(Error.NotFound(SalaryMessageKeys.SalaryNotFound));
        }
        GetSalaryDto salaryDto = mapper.Map<GetSalaryDto>(salary);
        return Result.Success(salaryDto);
    }
}