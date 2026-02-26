using Application.Features.Identities.Roles.Dtos;
using Application.Features.Identities.Roles.GetRoles;
using Domain.Identities.Enums;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Controllers;

public class RolesController : ApiBaseController
{
    [Authorize(Roles = nameof(Roles.Admin))]
    [HttpGet(Router.RolesRouter.GetRoles)]
    public async Task<IActionResult> GetRoles()
    {
        Result<List<RoleDto>> result = await mediator.Send(new GetRolesQuery());
        return result.ToActionResult();
    }
} 