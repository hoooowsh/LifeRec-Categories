using MediatR;
using Categories.API.v1.DBRepo;
using Categories.API.Configuration;
using Categories.API.MongoDBModel;
using Categories.API.v1.Model;

namespace Categories.API.v1.Request;

public class AddMenuItemReq : IRequest<Unit>
{
    public required AddMenuItemReqModel model { get; set; }
}

public class AddMenuItemReqHandler : IRequestHandler<AddMenuItemReq, Unit>
{
    private readonly IMongoDBRepository _mongoDBRepository;
    public AddMenuItemReqHandler(IMongoDBRepository mongoDBRepository)
    {
        _mongoDBRepository = mongoDBRepository;
    }

    public async Task<Unit> Handle(AddMenuItemReq request, CancellationToken cancellationToken)
    {
        string collectionName = MongoDBConstants.Collection_CookingMenu;
        MenuItemDBModel menuItem = new MenuItemDBModel
        {
            Name = request.model.Name,
            Description = request.model.Description,
            Owner = request.model.Owner,
            CreatedAt = request.model.CreatedAt,
            Steps = request.model.Steps,
            ImgUrl = request.model.ImgUrl
        };
        await _mongoDBRepository.CreateMenuItem(collectionName, menuItem);
        return Unit.Value;
    }
}