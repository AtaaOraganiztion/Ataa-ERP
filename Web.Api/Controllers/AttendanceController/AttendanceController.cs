using Application.Features.Attendance.Commands.Add;
using Application.Features.Attendance.Commands.UpdateStatus;
using Application.Features.Attendance.Dtos;
using Application.Features.Attendance.Queries.GetAll;
using Domain.Enums;
using Domain.Models.Attendance.Enums;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.AttendanceController;

public class AttendanceController() : ApiBaseController
{
    [HttpGet(Router.AttendanceRouter.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] AttendanceFilter filter)
    {
        Result<List<AttendanceDto>> result = await mediator.Send(new GetAttendanceQuery(filter));
        return result.ToActionResult();
    }

    [HttpPost(Router.AttendanceRouter.Add)]
    public async Task<IActionResult> Add([FromBody] AddAttendanceCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }

    [HttpPatch(Router.AttendanceRouter.UpdateStatus)]
    public async Task<IActionResult> UpdateStatus(Ulid id, [FromBody] UpdateAttendanceStatusRequest request)
    {
        Result<Ulid> result = await mediator.Send(
            new UpdateAttendanceStatusCommand(id, request.Status, request.Notes));
        return result.ToActionResult();
    }
}

public record UpdateAttendanceStatusRequest(AttendanceStatus Status, string? Notes);
