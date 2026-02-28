using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Employee.Dtos;
using Application.Features.Employee.Specifications;
using AutoMapper;
using Domain.Models.Employee;
using SharedKernel;

namespace Application.Features.Employee.Queries.GetById;

public class GetEmployeeByIdQueryHandler(IRepository<Domain.Models.Employee.Employee> repository, IMapper mapper) : IQueryHandler<GetEmployeeByIdQuery, GetEmployeeDto>
{
    public async Task<Result<GetEmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.Employee.Employee? employee = await repository.FirstOrDefaultAsync(new EmployeeByIdSpec(request.Id), cancellationToken);
        if (employee is null)
        {
            return Result.Failure<GetEmployeeDto>(Error.NotFound(EmployeeMessageKeys.EmployeeNotFound));
        }
        GetEmployeeDto employeeDto = mapper.Map<GetEmployeeDto>(employee);
        return Result.Success(employeeDto);
    }
}