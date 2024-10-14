using MediatR;
using Categories.API.v1.DBRepo;
using Categories.API.Configuration;
using Categories.API.Utils;

namespace Categories.API.v1.Request;

public class DeleteMenuItemReq : IRequest<Unit>
{
    public required string Id { get; set; }
}

public class DeleteMenuItemReqHandler : IRequestHandler<DeleteMenuItemReq, Unit>
{
    private readonly IMongoDBRepository _mongoDBRepository;
    public DeleteMenuItemReqHandler(IMongoDBRepository mongoDBRepository)
    {
        _mongoDBRepository = mongoDBRepository;
    }

    public async Task<Unit> Handle(DeleteMenuItemReq request, CancellationToken cancellationToken)
    {
        try
        {
            string collectionName = MongoDBConstants.Collection_CookingMenu;
            await _mongoDBRepository.DeleteMenuItemById(collectionName, request.Id);
            return Unit.Value;
        }
        catch (Exception e)
        {
            throw new RequestException(e.Message);
        }
    }
}