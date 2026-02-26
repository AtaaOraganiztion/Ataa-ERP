using Application.Abstractions.Messaging;
using Application.Features.Identities.Roles.Dtos;

namespace Application.Features.Identities.Roles.GetRoles;

public record GetRolesQuery : IQuery<List<RoleDto>>;
