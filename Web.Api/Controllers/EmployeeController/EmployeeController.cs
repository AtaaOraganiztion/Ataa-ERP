
using Application.Abstractions.Services;
using Application.Features.Employee.Commands.Add;
using Application.Features.Employee.Commands.Delete;
using Application.Features.Employee.Commands.Update;
using Application.Features.Employee.Dtos;
using Application.Features.Employee.Queries.GetAll;
using Application.Features.Employee.Queries.GetById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.EmployeeController;

public class EmployeeController() : ApiBaseController
{
    [HttpPost(Router.Employee.Add)]
    public async Task<IActionResult> AddEmployee([FromBody]AddEmployeeCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        
        return result.ToCreatedActionResult();
    }
    
    [HttpDelete(Router.Employee.Delete)]
    public async Task<IActionResult> DeleteEmployee(Ulid id)
    {
        Result<Ulid> result =
            await mediator.Send(new DeleteEmployeeCommand(id));
        return result.ToActionResult();
    }
    
    [HttpPut(Router.Employee.Update)]
    public async Task<IActionResult> UpdateEmployee(Ulid id, [FromBody] UpdateEmployeeDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateEmployeeCommand(id, request));
        return result.ToActionResult();
    }
    
    [HttpGet(Router.Employee.GetAll)]
    public async Task<IActionResult> GetAllEmployee([FromQuery] EmployeeFilter request)
    {
        Result<List<GetEmployeeDto>> result = await mediator.Send(new GetEmployeeQuery(request));
        return result.ToActionResult();
    }
    [HttpGet(Router.Employee.GetById)]
    public async Task<IActionResult> GetEmployeeById([FromRoute] Ulid id)
    {
        Result<GetEmployeeDto> result = await mediator.Send(new GetEmployeeByIdQuery(id));
        return result.ToActionResult();
    }
}