using Microsoft.AspNetCore.Mvc;

namespace Exercise02.API.Controllers;

[ApiController]
[Route("/customers")]
public class CustomerController : ControllerBase
{
    [HttpPost()]
    public IActionResult Post()
    {
        return Ok();
    }

    [HttpGet()]
    public IActionResult Get()
    {
        return Ok();
    }
}
