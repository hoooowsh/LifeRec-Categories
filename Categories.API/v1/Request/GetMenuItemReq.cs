using MediatR;
using Categories.API.v1.DBRepo;
using Categories.API.Configuration;
using Categories.API.MongoDBModel;
using Categories.API.Utils;

namespace Categories.API.v1.Request;

public class GetMenuItemReq : IRequest<MenuItemDBModel>
{
    public required string Id { get; set; }
}

public class GetMenuItemReqHandler : IRequestHandler<GetMenuItemReq, MenuItemDBModel>
{
    private readonly IMongoDBRepository _mongoDBRepository;
    public GetMenuItemReqHandler(IMongoDBRepository mongoDBRepository)
    {
        _mongoDBRepository = mongoDBRepository;
    }

    public async Task<MenuItemDBModel> Handle(GetMenuItemReq request, CancellationToken cancellationToken)
    {
        try
        {
            string collectionName = MongoDBConstants.Collection_CookingMenu;
            MenuItemDBModel MenuItem = await _mongoDBRepository.GetMenuItemById(collectionName, request.Id);
            return MenuItem;
        }
        catch (Exception e)
        {
            throw new RequestException(e.Message);
        }
    }
}