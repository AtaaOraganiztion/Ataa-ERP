using Application.Features.CRM.Lead.Commands.Add;
using Application.Features.CRM.Lead.Commands.Delete;
using Application.Features.CRM.Lead.Commands.Update;
using Application.Features.CRM.Lead.Dtos;
using Application.Features.CRM.Lead.Queries.GetAll;
using Application.Features.CRM.Lead.Queries.GetById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.CRM;

public class LeadController : ApiBaseController
{
    [HttpPost(Router.Lead.Add)]
    public async Task<IActionResult> AddLead([FromBody] AddLeadCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }

    [HttpDelete(Router.Lead.Delete)]
    public async Task<IActionResult> DeleteLead([FromRoute] Ulid id)
    {
        Result<Ulid> result = await mediator.Send(new DeleteLeadCommand(id));
        return result.ToActionResult();
    }

    [HttpPut(Router.Lead.Update)]
    public async Task<IActionResult> UpdateLead([FromRoute] Ulid id, [FromBody] UpdateLeadDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateLeadCommand(id, request));
        return result.ToActionResult();
    }

    [HttpGet(Router.Lead.GetAll)]
    public async Task<IActionResult> GetAllLeads([FromQuery] LeadFilter filter)
    {
        Result<List<GetLeadDto>> result = await mediator.Send(new GetLeadQuery(filter));
        return result.ToActionResult();
    }

    [HttpGet(Router.Lead.GetById)]
    public async Task<IActionResult> GetLeadById([FromRoute] Ulid id)
    {
        Result<GetLeadDto> result = await mediator.Send(new GetLeadByIdQuery(id));
        return result.ToActionResult();
    }
}