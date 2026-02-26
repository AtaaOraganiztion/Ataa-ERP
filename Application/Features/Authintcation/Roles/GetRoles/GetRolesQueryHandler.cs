using Application.Abstractions.Messaging;
using Application.Features.Identities.Roles.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Features.Identities.Roles.GetRoles;

public class GetRolesQueryHandler(RoleManager<Role> roleManager)
    : IQueryHandler<GetRolesQuery, List<RoleDto>>
{
    public async Task<Result<List<RoleDto>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        List<Role> roles = await roleManager.Roles.AsNoTracking().ToListAsync(cancellationToken);

        var roleDtos = roles.Select(role => new RoleDto(role.Id, role.Name!, role.Description)).ToList();

        return Result.Success(roleDtos);
    }
}
