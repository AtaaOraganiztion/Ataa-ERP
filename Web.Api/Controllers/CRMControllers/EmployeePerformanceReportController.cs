using Application.Features.CRM.EmployeePerformanceReport.Commands.Create;
using Application.Features.CRM.EmployeePerformanceReport.Commands.Delete;
using Application.Features.CRM.EmployeePerformanceReport.Commands.Update;
using Application.Features.CRM.EmployeePerformanceReport.Dtos;
using Application.Features.CRM.EmployeePerformanceReport.Queries.GetById;
using Application.Features.CRM.EmployeePerformanceReport.Queries.GetList;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.CRM;

public class EmployeePerformanceReportController : ApiBaseController
{
    [HttpPost(Router.EmployeePerformanceReport.Add)]
    public async Task<IActionResult> AddReport([FromBody] CreateEmployeePerformanceReportCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }

    [HttpPut(Router.EmployeePerformanceReport.Update)]
    public async Task<IActionResult> UpdateReport([FromRoute] Ulid id, [FromBody] UpdateEmployeePerformanceReportDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateEmployeePerformanceReportCommand(id, request));
        return result.ToActionResult();
    }

    [HttpDelete(Router.EmployeePerformanceReport.Delete)]
    public async Task<IActionResult> DeleteReport([FromRoute] Ulid id)
    {
        Result<Ulid> result = await mediator.Send(new DeleteEmployeePerformanceReportCommand(id));
        return result.ToActionResult();
    }

    [HttpGet(Router.EmployeePerformanceReport.GetById)]
    public async Task<IActionResult> GetReportById([FromRoute] Ulid id)
    {
        Result<EmployeePerformanceReportDto> result = await mediator.Send(new GetEmployeePerformanceReportByIdQuery(id));
        return result.ToActionResult();
    }

    [HttpGet(Router.EmployeePerformanceReport.GetAll)]
    public async Task<IActionResult> GetAllReports()
    {
        Result<List<EmployeePerformanceReportDto>> result = await mediator.Send(new GetEmployeePerformanceReportsQuery());
        return result.ToActionResult();
    }
}
