using MongoDB.Driver;
using Categories.API.MongoDBModel;
using Categories.API.Configuration;

namespace Categories.API.v1.DBRepo;

public interface IMongoDBRepository
{
    public Task CreateMenuItem(string collectionName, MenuItemDBModel category);
    public Task<List<MenuItemDBModel>> GetMenuItemsByOwner(string collectionName, string owner, int page);
}
public class MongoDBRepository : IMongoDBRepository
{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _categoriesDatabase;

    public MongoDBRepository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
        _categoriesDatabase = _mongoClient.GetDatabase(MongoDBConstants.DatabaseName);
    }

    public async Task CreateMenuItem(string collectionName, MenuItemDBModel menuItem)
    {
        // Init collection
        var collection = _categoriesDatabase.GetCollection<MenuItemDBModel>(collectionName);

        // Insert the menu item
        await collection.InsertOneAsync(menuItem);
    }

    public async Task<List<MenuItemDBModel>> GetMenuItemsByOwner(string collectionName, string owner, int page)
    {
        // Init collection
        var collection = _categoriesDatabase.GetCollection<MenuItemDBModel>(collectionName);

        // Get the menu items
        var menuItems = await collection.Find(x => x.Owner == owner)
            .SortBy(x => x.CreatedAt)
            .Skip((page - 1) * MongoDBConstants.PageSize)
            .Limit(MongoDBConstants.PageSize)
            .ToListAsync();
        return menuItems;
    }
}