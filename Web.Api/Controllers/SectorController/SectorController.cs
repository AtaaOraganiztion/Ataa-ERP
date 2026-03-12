using Application.Abstractions.Services;
using Application.Features.Sector.Commands.Add;
using Application.Features.Sector.Commands.Delete;
using Application.Features.Sector.Commands.Update;
using Application.Features.Sector.Dtos;
using Application.Features.Sector.Queries.GetAll;
using Application.Features.Sector.Queries.GetById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.SectorController;

public class SectorController() : ApiBaseController
{
    [HttpPost(Router.SectorRouter.Add)]
    public async Task<IActionResult> AddSector([FromBody] AddSectorCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        
        return result.ToCreatedActionResult();
    }
    [HttpDelete(Router.SectorRouter.Delete)]
    public async Task<IActionResult> DeleteSector(Ulid id)
    {
        Result<Ulid> result =
            await mediator.Send(new DeleteSectorCommand(id));
        return result.ToActionResult();
    }
    
    [HttpPut(Router.SectorRouter.Update)]
    public async Task<IActionResult> UpdateSector(Ulid id, [FromBody] UpdateSectorDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateSectorCommand(id, request));
        return result.ToActionResult();
    }
    
    [HttpGet(Router.SectorRouter.GetAll)]
    public async Task<IActionResult> GetAllSector([FromQuery] SectorFilter request)
    {
        Result<List<GetSectorDto>> result = await mediator.Send(new GetSectorQuery(request));
        return result.ToActionResult();
    }
    [HttpGet(Router.SectorRouter.GetById)]
    public async Task<IActionResult> GetSectorById([FromRoute] Ulid id)
    {
        Result<GetSectorDto> result = await mediator.Send(new GetSectorByIdQuery(id));
        return result.ToActionResult();
    }
    
   
}