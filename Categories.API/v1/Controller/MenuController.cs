using MediatR;
using Microsoft.AspNetCore.Mvc;
using Categories.API.v1.Model;
using Categories.API.v1.Request;

namespace Categories.API.v1.Controller;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1")]
public class MenuController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<MenuController> _logger;
    public MenuController(IMediator mediator, ILogger<MenuController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddMenuItem([FromBody] AddMenuItemReqModel model)
    {
        try
        {
            var request = new AddMenuItemReq
            {
                model = model
            };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding menu item: {ErrorMessage}", ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-list")]
    public async Task<IActionResult> GetMenuItemsByOwner([FromQuery] GetMenuItemsReqModel model)
    {
        try
        {
            var request = new GetMenuItemsReq
            {
                model = model
            };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding menu item: {ErrorMessage}", ex.Message);
            return BadRequest(ex.Message);
        }
    }
}