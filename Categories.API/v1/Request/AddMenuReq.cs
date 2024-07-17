using Categories.API.v1.Model;
using MediatR;
using Categories.API.v1.DBRepo;
using Categories.API.Configuration;

namespace Categories.API.v1.Request;

public class AddMenuReq : IRequest<Unit>
{
    public required MenuItem MenuItem { get; set; }
}

public class AddMenuReqHandler : IRequestHandler<AddMenuReq, Unit>
{
    private readonly IMongoDBRepository _mongoDBRepository;
    public AddMenuReqHandler(IMongoDBRepository mongoDBRepository)
    {
        _mongoDBRepository = mongoDBRepository;
    }

    public async Task<Unit> Handle(AddMenuReq request, CancellationToken cancellationToken)
    {
        string collectionName = MongoDBConstants.Collection_CookingMenu;
        await _mongoDBRepository.CreateMenuItem(collectionName, request.MenuItem);
        return Unit.Value;
    }
}