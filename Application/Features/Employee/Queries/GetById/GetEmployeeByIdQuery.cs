using Application.Abstractions.Messaging;
using Application.Features.Employee.Dtos;


namespace Application.Features.Employee.Queries.GetById;

public record GetEmployeeByIdQuery(Ulid Id) : IQuery<GetEmployeeDto>;