
using Application.Features.finance.Budget.Commands.Add;
using Application.Features.finance.Budget.Commands.Delete;
using Application.Features.finance.Budget.Commands.Update;
using Application.Features.finance.Budget.Dtos;
using Application.Features.finance.Budget.Queries.GetAll;
using Application.Features.finance.Budget.Queries.GetById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.FinanceController.BudgetController;

public class BudgetController() : ApiBaseController
{
    [HttpPost(Router.Budget.Add)]
    public async Task<IActionResult> AddBudget([FromBody] AddBudgetCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }

    [HttpDelete(Router.Budget.Delete)]
    public async Task<IActionResult> DeleteBudget(Ulid id)
    {
        Result<Ulid> result = await mediator.Send(new DeleteBudgetCommand(id));
        return result.ToActionResult();
    }

    [HttpPut(Router.Budget.Update)]
    public async Task<IActionResult> UpdateBudget(Ulid id, [FromBody] UpdateBudgetDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateBudgetCommand(id, request));
        return result.ToActionResult();
    }

    [HttpGet(Router.Budget.GetAll)]
    public async Task<IActionResult> GetAllBudgets([FromQuery] BudgetFilter request)
    {
        Result<List<GetBudgetDto>> result = await mediator.Send(new GetBudgetQuery(request));
        return result.ToActionResult();
    }

    [HttpGet(Router.Budget.GetById)]
    public async Task<IActionResult> GetBudgetById([FromRoute] Ulid id)
    {
        Result<GetBudgetDto> result = await mediator.Send(new GetBudgetByIdQuery(id));
        return result.ToActionResult();
    }
}