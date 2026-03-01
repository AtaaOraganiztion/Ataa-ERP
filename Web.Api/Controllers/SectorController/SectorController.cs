using Application.Abstractions.Services;
using Application.Features.Sector.Commands.Add;
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
    
   
}