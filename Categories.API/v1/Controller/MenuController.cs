using Categories.API.v1.Model;
using Categories.API.v1.Request;
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

    [HttpPost("create")]
    public async Task<IActionResult> AddMenu(AddMenuItemRequestModel model)
    {
        try
        {
            var request = new AddMenuReq
            {
                MenuItem = model
            };
            await _mediator.Send(request);
            return Ok("test");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}