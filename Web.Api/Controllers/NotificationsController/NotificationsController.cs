using Application.Features.Notifications.Commands;
using Application.Features.Notifications.Dtos;
using Application.Features.Notifications.Queries;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers;

public class NotificationsController : ApiBaseController
{
    [HttpGet(Router.Notifications.Latest)]
    public async Task<IActionResult> GetLatestNotifications()
    {
        Result<NotificationsDto> result = await mediator.Send(new GetInternalNotificationsQuery());
        return result.ToActionResult();
    }

    [HttpPut(Router.Notifications.MarkAsRead)]
    public async Task<IActionResult> MarkNotificationAsRead([FromRoute] Ulid id)
    {
        Result<Ulid> result = await mediator.Send(new MarkNotificationAsReadCommand(id));
        return result.ToActionResult();
    }
}
