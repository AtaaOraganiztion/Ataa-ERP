using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Identities;
using Microsoft.AspNetCore.Identity;
using SharedKernel;

namespace Application.Features.Identities.Users.UpdateUserRoles;

public class UpdateUserRolesCommandHandler(UserManager<Domain.Entities.User> userManager, RoleManager<Role> roleManager)
    : ICommandHandler<UpdateUserRolesCommand>
{
    public async Task<Result> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
    {
        // get user
        Domain.Entities.User? user = await userManager.FindByIdAsync(request.UserId.ToString());

        if (user is null)
        {
            return Result.Failure(Error.NotFound(IdentityMessageKeys.UserNotFound));
        }

        // get roles
        Result<List<Role>> newRoles = await GetRolesByIdsAsync(request.RolesIds);

        if (newRoles.IsFailure)
        {
            return newRoles;
        }

        // get current roles
        IList<string> currentRoles = await userManager.GetRolesAsync(user);


        // remove current roles
        Result removeResult = await RemoveCurrentRolesAsync(user, currentRoles);

        if (removeResult.IsFailure)
        {
            return removeResult;
        }

        // add new roles
        IdentityResult addResult = await userManager.AddToRolesAsync(user, newRoles.Value.Select(r => r.Name)!);

        if (addResult.Succeeded)
        {
            return Result.Success();
        }

        IEnumerable<Error> errors = addResult.Errors
            .Select(e => new Error(e.Code, ErrorType.Validation));

        return Result.Failure(new ValidationError([.. errors]));
    }


    private async Task<Result<List<Role>>> GetRolesByIdsAsync(IList<Ulid> ids)
    {
        List<Role> identityRoles = [];

        foreach (Ulid roleId in ids)
        {
            Role? role = await roleManager.FindByIdAsync(roleId.ToString());
            if (role is null)
            {
                return Result.Failure<List<Role>>(Error.NotFound(IdentityMessageKeys.RoleNotFound));
            }

            identityRoles.Add(role);
        }

        return Result.Success(identityRoles);
    }

    private async Task<Result> RemoveCurrentRolesAsync(Domain.Entities.User user, IList<string> currentRoles)
    {
        // remove current roles
        IdentityResult removeResult = await userManager.RemoveFromRolesAsync(user, currentRoles);

        if (removeResult.Succeeded)
        {
            return Result.Success();
        }

        IEnumerable<Error> errors = removeResult.Errors
            .Select(e => new Error(e.Code, ErrorType.Validation));

        return Result.Failure(new ValidationError([.. errors]));
    }
}
