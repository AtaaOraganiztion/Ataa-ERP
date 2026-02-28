using Application.Abstractions.Messaging;
using Application.Features.Employee.Dtos;


namespace Application.Features.Employee.Queries.GetAll;

public record GetEmployeeQuery(EmployeeFilter EmployeeFilter) : IQuery<List<GetEmployeeDto>>;