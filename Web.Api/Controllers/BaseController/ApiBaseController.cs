using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.BaseController;

[ApiController]
public class ApiBaseController : ControllerBase
{
    private IMediator _mediator = null!;
    protected IMediator mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
    
    private IConfiguration _configuration = null!;
    protected IConfiguration configuration => _configuration ??= HttpContext.RequestServices.GetService<IConfiguration>()!;
}