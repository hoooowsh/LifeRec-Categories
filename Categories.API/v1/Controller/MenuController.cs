using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1")]
public class MenuController : ControllerBase
{
    private readonly IMediator _mediator;
    public MenuController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("hello")]
    public async Task<IActionResult> Hello()
    {
        return Ok("Hello World!");
    }
}