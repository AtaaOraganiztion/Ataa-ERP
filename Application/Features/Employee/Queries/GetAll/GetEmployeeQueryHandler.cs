using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Employee.Dtos;
using Application.Features.Employee.Specifications;

using AutoMapper;
using SharedKernel;

namespace Application.Features.Employee.Queries.GetAll;

public class GetEmployeeQueryHandler(IRepository<Domain.Models.Employee.Employee> repository, IMapper mapper) : IQueryHandler<GetEmployeeQuery, List<GetEmployeeDto>>
{
    public async Task<Result<List<GetEmployeeDto>>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.Employee.Employee> employees = await repository.ListAsync(
            new GetEmployeeSpec(request.EmployeeFilter),
            cancellationToken);
            
        List<GetEmployeeDto> contactFormDtos = mapper.Map<List<GetEmployeeDto>>(employees);
        return Result.Success(contactFormDtos);
    }
}