using Application.Abstractions.Messaging;
using Application.Features.Salary.Dtos;


namespace Application.Features.Salary.Queries.GetAll;

public record GetSalaryQuery(SalaryFilter SalaryFilter) : IQuery<List<GetSalaryDto>>;