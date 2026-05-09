using Application.Features.Adverisment.Commands.Add;
using Application.Features.Adverisment.Commands.Delete;
using Application.Features.Adverisment.Commands.Update;
using Application.Features.Adverisment.Dtos;
using Application.Features.Adverisment.Queries.GetAll;
using Application.Features.Adverisment.Queries.GetById;
using Application.Features.Adverisment.Queries.GetFileById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers;

public class AdverismentController : ApiBaseController
{
    private readonly IFileStorageService fileStorage;

    public AdverismentController(IFileStorageService fileStorage)
    {
        this.fileStorage = fileStorage;
    }

    [HttpPost(Router.Adverisment.Add)]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> AddAdverisment([FromForm] AddAdverismentCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }

    [HttpDelete(Router.Adverisment.Delete)]
    public async Task<IActionResult> DeleteAdverisment([FromRoute] Ulid id)
    {
        Result<Ulid> result = await mediator.Send(new DeleteAdverismentCommand(id));
        return result.ToActionResult();
    }

    [HttpPut(Router.Adverisment.Update)]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateAdverisment([FromRoute] Ulid id, [FromForm] UpdateAdverismentDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateAdverismentCommand(id, request));
        return result.ToActionResult();
    }

    [HttpGet(Router.Adverisment.GetAll)]
    public async Task<IActionResult> GetAllActivities([FromQuery] AdverismentFilter filter)
    {
        Result<List<GetAdverismentDto>> result = await mediator.Send(new GetAdverismentQuery(filter));
        return result.ToActionResult();
    }

    [HttpGet(Router.Adverisment.GetById)]
    public async Task<IActionResult> GetAdverismentById([FromRoute] Ulid id)
    {
        Result<GetAdverismentDto> result = await mediator.Send(new GetAdverismentByIdQuery(id));
        return result.ToActionResult();
    }
    [HttpGet(Router.Adverisment.DownloadFile)]
    public async Task<IActionResult> DownloadFile(Ulid fileId, [FromQuery] bool download = false)
    {
        var result = await mediator.Send(new GetAdverismentFileByIdQuery(fileId));

        if (result.IsFailure)
            return NotFound(result.Error);

        var file = result.Value;
        var stream = fileStorage.GetFileStream(file.StoragePath);

        if (!download && file.ContentType != null && file.ContentType.StartsWith("image/"))
        {
            return File(stream, file.ContentType);
        }

        return File(stream, file.ContentType, file.FileName, enableRangeProcessing: true);
    }
}