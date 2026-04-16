using Application.Features.CRM.Deal.Commands.Add;
using Application.Features.CRM.Deal.Commands.Delete;
using Application.Features.CRM.Deal.Commands.Update;
using Application.Features.CRM.Deal.Dtos;
using Application.Features.CRM.Deal.Queries.GetAll;
using Application.Features.CRM.Deal.Queries.GetById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.CRM;

public class DealController : ApiBaseController
{
    [HttpPost(Router.Deal.Add)]
    public async Task<IActionResult> AddDeal([FromBody] AddDealCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }

    [HttpDelete(Router.Deal.Delete)]
    public async Task<IActionResult> DeleteDeal([FromRoute] Ulid id)
    {
        Result<Ulid> result = await mediator.Send(new DeleteDealCommand(id));
        return result.ToActionResult();
    }

    [HttpPut(Router.Deal.Update)]
    public async Task<IActionResult> UpdateDeal([FromRoute] Ulid id, [FromBody] UpdateDealDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateDealCommand(id, request));
        return result.ToActionResult();
    }

    [HttpGet(Router.Deal.GetAll)]
    public async Task<IActionResult> GetAllDeals([FromQuery] DealFilter filter)
    {
        Result<List<GetDealDto>> result = await mediator.Send(new GetDealQuery(filter));
        return result.ToActionResult();
    }

    [HttpGet(Router.Deal.GetById)]
    public async Task<IActionResult> GetDealById([FromRoute] Ulid id)
    {
        Result<GetDealDto> result = await mediator.Send(new GetDealByIdQuery(id));
        return result.ToActionResult();
    }
}