using Application.Features.Finance.Expense.Commands.Add;
using Application.Features.Finance.Expense.Commands.Delete;
using Application.Features.Finance.Expense.Commands.Update;
using Application.Features.Finance.Expense.Dtos;
using Application.Features.Finance.Expense.Queries.GetAll;
using Application.Features.Finance.Expense.Queries.GetById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.ExpenseController;

public class ExpenseController() : ApiBaseController
{
    [HttpPost(Router.Expense.Add)]
    public async Task<IActionResult> AddExpense([FromBody] AddExpenseCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }

    [HttpDelete(Router.Expense.Delete)]
    public async Task<IActionResult> DeleteExpense(Ulid id)
    {
        Result<Ulid> result = await mediator.Send(new DeleteExpenseCommand(id));
        return result.ToActionResult();
    }

    [HttpPut(Router.Expense.Update)]
    public async Task<IActionResult> UpdateExpense(Ulid id, [FromBody] UpdateExpenseDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateExpenseCommand(id, request));
        return result.ToActionResult();
    }

    [HttpGet(Router.Expense.GetAll)]
    public async Task<IActionResult> GetAllExpenses([FromQuery] ExpenseFilter request)
    {
        Result<List<GetExpenseDto>> result = await mediator.Send(new GetExpenseQuery(request));
        return result.ToActionResult();
    }

    [HttpGet(Router.Expense.GetById)]
    public async Task<IActionResult> GetExpenseById([FromRoute] Ulid id)
    {
        Result<GetExpenseDto> result = await mediator.Send(new GetExpenseByIdQuery(id));
        return result.ToActionResult();
    }
}