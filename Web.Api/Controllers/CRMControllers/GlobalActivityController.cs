using Application.Features.CRM.GlobalActivity.Commands.Add;
using Application.Features.CRM.GlobalActivity.Commands.Delete;
using Application.Features.CRM.GlobalActivity.Commands.Update;
using Application.Features.CRM.GlobalActivity.Dtos;
using Application.Features.CRM.GlobalActivity.Queries.GetById;
using Application.Features.CRM.GlobalActivity.Queries.GetFileById;
using Application.Features.CRM.GlobalActivity.Queries.GetList;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.CRM;

public class GlobalActivityController : ApiBaseController
{
    private readonly IFileStorageService fileStorage;

    public GlobalActivityController(IFileStorageService fileStorage)
    {
        this.fileStorage = fileStorage;
    }

    [HttpPost(Router.GlobalActivity.Add)]
    [Consumes("multipart/form-data")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddGlobalActivity([FromForm] AddGlobalActivityCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }

    [HttpDelete(Router.GlobalActivity.Delete)]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteGlobalActivity([FromRoute] Ulid id)
    {
        Result result = await mediator.Send(new DeleteGlobalActivityCommand(id));
        return result.ToActionResult();
    }

    [HttpPut(Router.GlobalActivity.Update)]
    [Consumes("multipart/form-data")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateGlobalActivity([FromRoute] Ulid id, [FromForm] UpdateGlobalActivityDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateGlobalActivityCommand(id, request));
        return result.ToActionResult();
    }

    [HttpGet(Router.GlobalActivity.GetAll)]
    public async Task<IActionResult> GetAllGlobalActivities([FromQuery] GlobalActivityFilter filter)
    {
        Result<List<GetGlobalActivityDto>> result = await mediator.Send(new GetGlobalActivitiesQuery(filter));
        return result.ToActionResult();
    }

    [HttpGet(Router.GlobalActivity.GetById)]
    public async Task<IActionResult> GetGlobalActivityById([FromRoute] Ulid id)
    {
        Result<GetGlobalActivityDto> result = await mediator.Send(new GetGlobalActivityQuery(id));
        return result.ToActionResult();
    }

    [HttpGet("api/v1/global-activity/files/{id}")]
    public async Task<IActionResult> DownloadFile(Ulid id)
    {
        var result = await mediator.Send(new GetGlobalActivityFileByIdQuery(id));

        if (result.IsFailure)
            return NotFound(result.Error);

        var file = result.Value;
        var stream = fileStorage.GetFileStream(file.StoragePath);

        return File(stream, file.ContentType, file.FileName, enableRangeProcessing: true);
    }
}
