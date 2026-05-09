using Application.Features.Foras.Commands.Add;
using Application.Features.Foras.Commands.Delete;
using Application.Features.Foras.Commands.Update;
using Application.Features.Foras.Dtos;
using Application.Features.Foras.Queries.GetAll;
using Application.Features.Foras.Queries.GetById;
using Application.Features.Foras.Queries.GetFileById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers;

public class ForasController : ApiBaseController
{
    private readonly IFileStorageService fileStorage;

    public ForasController(IFileStorageService fileStorage)
    {
        this.fileStorage = fileStorage;
    }

    [HttpPost(Router.Foras.Add)]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> AddForas([FromForm] AddForasCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }

    [HttpDelete(Router.Foras.Delete)]
    public async Task<IActionResult> DeleteForas([FromRoute] Ulid id)
    {
        Result<Ulid> result = await mediator.Send(new DeleteForasCommand(id));
        return result.ToActionResult();
    }

    [HttpPut(Router.Foras.Update)]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateForas([FromRoute] Ulid id, [FromForm] UpdateForasDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateForasCommand(id, request));
        return result.ToActionResult();
    }

    [HttpGet(Router.Foras.GetAll)]
    public async Task<IActionResult> GetAllForas([FromQuery] ForasFilter filter)
    {
        Result<List<GetForasDto>> result = await mediator.Send(new GetForasQuery(filter));
        return result.ToActionResult();
    }

    [HttpGet(Router.Foras.GetById)]
    public async Task<IActionResult> GetForasById([FromRoute] Ulid id)
    {
        Result<GetForasDto> result = await mediator.Send(new GetForasByIdQuery(id));
        return result.ToActionResult();
    }

    [HttpGet(Router.Foras.DownloadFile)]
    public async Task<IActionResult> DownloadFile(Ulid fileId, [FromQuery] bool download = false)
    {
        var result = await mediator.Send(new GetForasFileByIdQuery(fileId));

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
