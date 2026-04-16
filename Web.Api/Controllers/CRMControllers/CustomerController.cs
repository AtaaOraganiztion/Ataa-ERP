using Application.Features.CRM.Customer.Commands.Add;
using Application.Features.CRM.Customer.Commands.Delete;
using Application.Features.CRM.Customer.Commands.Update;
using Application.Features.CRM.Customer.Dtos;
using Application.Features.Customer.Queries.GetAll;
using Application.Features.CRM.Customer.Queries.GetById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.CRM;

public class CustomerController : ApiBaseController
{
    [HttpPost(Router.Customer.Add)]
    public async Task<IActionResult> AddCustomer([FromBody] AddCustomerCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }

    [HttpDelete(Router.Customer.Delete)]
    public async Task<IActionResult> DeleteCustomer([FromRoute] Ulid id)
    {
        Result<Ulid> result = await mediator.Send(new DeleteCustomerCommand(id));
        return result.ToActionResult();
    }

    [HttpPut(Router.Customer.Update)]
    public async Task<IActionResult> UpdateCustomer([FromRoute] Ulid id, [FromBody] UpdateCustomerDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateCustomerCommand(id, request));
        return result.ToActionResult();
    }

    [HttpGet(Router.Customer.GetAll)]
    public async Task<IActionResult> GetAllCustomers([FromQuery] CustomerFilter filter)
    {
        Result<List<GetCustomerDto>> result = await mediator.Send(new GetCustomerQuery(filter));
        return result.ToActionResult();
    }

    [HttpGet(Router.Customer.GetById)]
    public async Task<IActionResult> GetCustomerById([FromRoute] Ulid id)
    {
        Result<GetCustomerDto> result = await mediator.Send(new GetCustomerByIdQuery(id));
        return result.ToActionResult();
    }
}