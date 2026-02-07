using Microsoft.AspNetCore.Mvc;
using Web.Api.Controllers.BaseController;

namespace Web.Api.Controllers.HealthCheck;

public class HealthCheckController : ApiBaseController
{
    [HttpGet("health")]
    public IActionResult HealthCheck()
    {
        return Ok("API is running.");
    }
    
}