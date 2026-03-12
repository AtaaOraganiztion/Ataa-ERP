
using Application.Abstractions.Services;
using Application.Features.Salary.Commands.Add;
using Application.Features.Salary.Commands.Delete;
using Application.Features.Salary.Commands.Update;
using Application.Features.Salary.Dtos;
using Application.Features.Salary.Queries.GetAll;
using Application.Features.Salary.Queries.GetById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.EmployeeController;

public class SalaryController() : ApiBaseController
{
    [HttpPost(Router.Salary.Add)]
    public async Task<IActionResult> AddSalary([FromBody] AddSalaryCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);

        return result.ToCreatedActionResult();
    }

    [HttpDelete(Router.Salary.Delete)]
    public async Task<IActionResult> DeleteEmployee(Ulid id)
    {
        Result<Ulid> result =
            await mediator.Send(new DeleteSalaryCommand(id));
        return result.ToActionResult();
    }

    [HttpPut(Router.Salary.Update)]
    public async Task<IActionResult> UpdateSalary(Ulid id, [FromBody] UpdateSalaryDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateSalaryCommand(id, request));
        return result.ToActionResult();
    }

    [HttpGet(Router.Salary.GetAll)]
    public async Task<IActionResult> GetAllSalary([FromQuery] SalaryFilter request)
    {
        Result<List<GetSalaryDto>> result = await mediator.Send(new GetSalaryQuery(request));
        return result.ToActionResult();
    }
    [HttpGet(Router.Salary.GetById)]
    public async Task<IActionResult> GetSalarynById([FromRoute] Ulid id)
    {
        Result<GetSalaryDto> result = await mediator.Send(new GetSalaryByIdQuery(id));
        return result.ToActionResult();
    }
}