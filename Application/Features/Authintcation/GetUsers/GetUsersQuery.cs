using Application.Abstractions.Messaging;
using Application.Features.Identities.Dtos;
using SharedKernel;

namespace Application.Features.Authintcation.GetUsers;

public record GetUsersQuery(UserFilter Filter) : IQuery<PaginatedResponse<UserDto>>;
