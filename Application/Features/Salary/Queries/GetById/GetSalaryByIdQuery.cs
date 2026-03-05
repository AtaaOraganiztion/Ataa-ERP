using Application.Abstractions.Messaging;
using Application.Features.Salary.Dtos;


namespace Application.Features.Salary.Queries.GetById;

public record GetSalaryByIdQuery(Ulid Id) : IQuery<GetSalaryDto>;