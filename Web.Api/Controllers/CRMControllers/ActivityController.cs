using Application.Features.CRM.Activity.Commands.Add;
using Application.Features.CRM.Activity.Commands.Delete;
using Application.Features.CRM.Activity.Commands.Update;
using Application.Features.CRM.Activity.Dtos;
using Application.Features.CRM.Activity.Queries.GetAll;
using Application.Features.CRM.Activity.Queries.GetById;
using Application.Features.CRM.Activity.Queries.GetFileById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.CRM;

public class ActivityController : ApiBaseController
{
    private readonly IFileStorageService fileStorage;

    public ActivityController(IFileStorageService fileStorage)
    {
        this.fileStorage = fileStorage;
    }

    [HttpPost(Router.Activity.Add)]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> AddActivity([FromForm] AddActivityCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }

    [HttpDelete(Router.Activity.Delete)]
    public async Task<IActionResult> DeleteActivity([FromRoute] Ulid id)
    {
        Result<Ulid> result = await mediator.Send(new DeleteActivityCommand(id));
        return result.ToActionResult();
    }

    [HttpPut(Router.Activity.Update)]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateActivity([FromRoute] Ulid id, [FromForm] UpdateActivityDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateActivityCommand(id, request));
        return result.ToActionResult();
    }

    [HttpGet(Router.Activity.GetAll)]
    public async Task<IActionResult> GetAllActivities([FromQuery] ActivityFilter filter)
    {
        Result<List<GetActivityDto>> result = await mediator.Send(new GetActivityQuery(filter));
        return result.ToActionResult();
    }

    [HttpGet(Router.Activity.GetById)]
    public async Task<IActionResult> GetActivityById([FromRoute] Ulid id)
    {
        Result<GetActivityDto> result = await mediator.Send(new GetActivityByIdQuery(id));
        return result.ToActionResult();
    }
    [HttpGet("files/{id}")]
    public async Task<IActionResult> DownloadFile(Ulid id)
    {
        var result = await mediator.Send(new GetActivityFileByIdQuery(id));

        if (result.IsFailure)
            return NotFound(result.Error);

        var file = result.Value;
        var stream = fileStorage.GetFileStream(file.StoragePath);

       
        return File(stream, file.ContentType, file.FileName, enableRangeProcessing: true);
    }
}