using Microsoft.AspNetCore.Mvc;

namespace database_service.Controllers;

[ApiController]
public class PingController : ControllerBase
{
    [HttpGet("/ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }
}