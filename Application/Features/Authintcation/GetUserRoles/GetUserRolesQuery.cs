using Application.Abstractions.Messaging;
using Application.Features.Identities.Dtos;
using Application.Features.Identities.Roles.Dtos;

namespace Application.Features.Identities.Users.GetUserRoles;

public record GetUserRolesQuery(Ulid UserId) : IQuery<List<RoleDto>>;
