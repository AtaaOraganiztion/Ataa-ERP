using Application.Abstractions.Messaging;
using Application.Features.Identities.Roles.Dtos;
using Domain.Entities;
using Domain.Identities;
using Microsoft.AspNetCore.Identity;
using SharedKernel;

namespace Application.Features.Identities.Users.GetUserRoles;

public class GetUserRolesQueryHandler(UserManager<Domain.Entities.User> userManager, RoleManager<Role> roleManager)
    : IQueryHandler<GetUserRolesQuery, List<RoleDto>>
{
    public async Task<Result<List<RoleDto>>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        Domain.Entities.User? user = await userManager.FindByIdAsync(request.UserId.ToString());

        if (user is null)
        {
            return Result.Failure<List<RoleDto>>(Error.NotFound(IdentityMessageKeys.UserNotFound));
        }

        var rolesDtos = new List<RoleDto>();

        IList<string> roles = await userManager.GetRolesAsync(user);

        foreach (string role in roles)
        {
            Role identityRole = await roleManager.FindByNameAsync(role);

            rolesDtos.Add(new RoleDto(identityRole!.Id, identityRole.Name!, identityRole.Description));
        }

        return Result.Success(rolesDtos);
    }
}
