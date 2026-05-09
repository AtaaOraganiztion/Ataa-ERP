using Application.Abstractions.Messaging;
using Application.Features.Identities.Dtos;
using SharedKernel;

namespace Application.Features.Authintcation.GetDesigners;

public record GetDesignersQuery(UserFilter Filter) : IQuery<PaginatedResponse<UserDto>>;
