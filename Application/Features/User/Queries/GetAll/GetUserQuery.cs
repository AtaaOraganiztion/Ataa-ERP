using Application.Abstractions.Messaging;
using Application.Features.User.Dtos;


namespace Application.Features.User.Queries.GetAll;

public record GetUserQuery(UserFilter BudgetFilter) : IQuery<List<GetUserDto>>;