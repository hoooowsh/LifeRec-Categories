using Categories.API.v1.Model;
using MediatR;
using Categories.API.v1.DBRepo;
using Categories.API.Configuration;
using Categories.API.MongoDBModel;
using Categories.API.Utils;

namespace Categories.API.v1.Request;

public class GetMenuItemsReq : IRequest<GetMenuItemsResModel>
{
    public required GetMenuItemsReqModel model { get; set; }
}

public class GetMenuItemsReqHandler : IRequestHandler<GetMenuItemsReq, GetMenuItemsResModel>
{
    private readonly IMongoDBRepository _mongoDBRepository;
    public GetMenuItemsReqHandler(IMongoDBRepository mongoDBRepository)
    {
        _mongoDBRepository = mongoDBRepository;
    }

    public async Task<GetMenuItemsResModel> Handle(GetMenuItemsReq request, CancellationToken cancellationToken)
    {
        try
        {
            string collectionName = MongoDBConstants.Collection_CookingMenu;
            List<MenuItemDBModel> MenuItems = await _mongoDBRepository.GetMenuItemsByOwner(collectionName, request.model.Owner, request.model.Page);
            GetMenuItemsResModel res = new GetMenuItemsResModel
            {
                MenuItems = MenuItems
            };
            return res;
        }
        catch (Exception e)
        {
            throw new RequestException(e.Message);
        }
    }
}