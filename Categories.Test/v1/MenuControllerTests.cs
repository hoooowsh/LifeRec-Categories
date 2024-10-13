using Microsoft.AspNetCore.Mvc;
using Moq;
using Categories.API.v1.Controller;
using Categories.API.v1.Model;
using MediatR;
using Categories.API.v1.Request;
using Microsoft.Extensions.Logging;

public class MenuItemControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<ILogger<MenuItemController>> _logger;
    private readonly MenuItemController _menuItemController;

    public MenuItemControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _logger = new Mock<ILogger<MenuItemController>>();
        _menuItemController = new MenuItemController(_mediatorMock.Object, _logger.Object);
    }

    [Fact(DisplayName = "AddMenuItem_Success")]
    public async Task AddMenuItem_Success()
    {
        // Arrange
        var model = new AddMenuItemReqModel
        {
            Name = "Test_Name",
            Description = "Test_Description",
            Owner = "Test_Owner",
            CreatedAt = new DateTime(2021, 1, 1),
            Steps = new List<string> { "Step_1", "Step_2" },
            ImgUrl = "Test_ImgUrl"
        };
        var request = new AddMenuItemReq
        {
            model = model
        };
        _mediatorMock.Setup(x => x.Send(request, It.IsAny<CancellationToken>())).ReturnsAsync(Unit.Value);

        // Act
        var result = await _menuItemController.AddMenuItem(model);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}