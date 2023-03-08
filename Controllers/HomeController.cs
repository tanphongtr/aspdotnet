using Microsoft.AspNetCore.Mvc;

namespace AspNetAPI.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetHome")]
    public IActionResult Get()
    {
        return Ok(
            new { message = "Hello World!" }
        );
    }


    // create route return json
    [HttpGet("json", Name = "GetHomeJson")]
    public IActionResult GetJson()
    {
        return new JsonResult(
            new { message = "Hello World!" }
        );
    }
}

