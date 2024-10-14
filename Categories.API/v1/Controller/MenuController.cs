using MediatR;
using Microsoft.AspNetCore.Mvc;
using Categories.API.v1.Model;
using Categories.API.v1.Request;

namespace Categories.API.v1.Controller;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1")]
public class MenuItemController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<MenuItemController> _logger;
    public MenuItemController(IMediator mediator, ILogger<MenuItemController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("")]
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

    [HttpGet("")]
    public async Task<IActionResult> GetMenuItemById([FromQuery] string id)
    {
        try
        {
            var request = new GetMenuItemReq
            {
                Id = id
            };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting menu item: {ErrorMessage}", ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("")]
    public async Task<IActionResult> DeleteMenuItemById([FromQuery] string id)
    {
        try
        {
            var request = new DeleteMenuItemReq
            {
                Id = id
            };
            await _mediator.Send(request);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting menu item: {ErrorMessage}", ex.Message);
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
            _logger.LogError(ex, "Error getting menu items: {ErrorMessage}", ex.Message);
            return BadRequest(ex.Message);
        }
    }
}