using Application.Features.Authintcation.GetUsers;
using Application.Features.Identities.Dtos;
using Application.Features.Identities.Roles.Dtos;
using Application.Features.Identities.Users.GetUserRoles;
using Application.Features.Identities.Users.Login;
using Application.Features.Identities.Users.Register;
using Application.Features.Identities.Users.UpdateUser;
using Application.Features.Identities.Users.UpdateUserRoles;
using Domain.Identities.Enums;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers;

public class UsersController() : ApiBaseController
{
    // Authentication endpoints (no authorization required)
    [HttpPost(Router.AuthinticationRouter.Login)]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand request)
    {
        Result<TokenResponseDto> result = await mediator.Send(request);
        return result.ToActionResult();
    }
    
    [HttpPost(Router.AuthinticationRouter.Register)]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand request)
    {
        Result result = await mediator.Send(request);
        return result.ToActionResult();
    }

    
    [Authorize(Roles = nameof(Roles.Admin))]
    [HttpPut(Router.AuthinticationRouter.UpdateUser)]
    public async Task<IActionResult> UpdateUser([FromRoute] Ulid userId, [FromBody] UpdateUserDto updateUserDto)
    {
        Result result = await mediator.Send(new UpdateUserCommand(userId, updateUserDto));
        return result.ToActionResult();
    }

    [Authorize(Roles = nameof(Roles.Admin))]
    [HttpGet(Router.AuthinticationRouter.GetUserRoles)]
    public async Task<IActionResult> GetUserRoles([FromRoute] Ulid userId)
    {
        Result<List<RoleDto>> result = await mediator.Send(new GetUserRolesQuery(userId));
        return result.ToActionResult();
    }

    [Authorize(Roles = nameof(Roles.Admin))]
    [HttpPut(Router.AuthinticationRouter.UpdateUserRoles)]
    public async Task<IActionResult> UpdateUserRoles([FromRoute] Ulid userId, [FromBody] List<Ulid> roleIds)
    {
        Result result = await mediator.Send(new UpdateUserRolesCommand(userId, roleIds));
        return result.ToActionResult();
    }
    
    [Authorize(Roles = nameof(Roles.Admin))]
    [HttpGet(Router.AuthinticationRouter.GetUsers)]
    public async Task<IActionResult> GetUsers([FromQuery] UserFilter filter)
    {
        Result<PaginatedResponse<UserDto>> result = await mediator.Send(new GetUsersQuery(filter));
        return result.ToActionResult();
    }

} 