using Categories.API.v1.Model;
using Categories.API.v1.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Categories.API.v1.Controller;

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
            return BadRequest(ex.Message);
        }
    }
}