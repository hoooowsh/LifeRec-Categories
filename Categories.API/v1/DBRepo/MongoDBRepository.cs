using MongoDB.Driver;
using Categories.API.MongoDBModel;
using Categories.API.Configuration;
using Categories.API.Utils;
using MediatR;

namespace Categories.API.v1.DBRepo;

public interface IMongoDBRepository
{
    public Task CreateMenuItem(string collectionName, MenuItemDBModel category);
    public Task<List<MenuItemDBModel>> GetMenuItemsByOwner(string collectionName, string owner, int page);
    public Task<MenuItemDBModel> GetMenuItemById(string collectionName, string id);
    public Task<Unit> DeleteMenuItemById(string collectionName, string id);
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

    /**
    * Create menu item in database
    */
    public async Task CreateMenuItem(string collectionName, MenuItemDBModel menuItem)
    {
        try
        {
            // Init collection
            var collection = _categoriesDatabase.GetCollection<MenuItemDBModel>(collectionName);

            // Insert the menu item
            await collection.InsertOneAsync(menuItem);
        }
        catch (Exception e)
        {
            throw new DatabaseException(e.Message);
        }
    }

    /**
    * Get menu items list by owner and page
    */
    public async Task<List<MenuItemDBModel>> GetMenuItemsByOwner(string collectionName, string owner, int page)
    {
        try
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
        catch (Exception e)
        {
            throw new DatabaseException(e.Message);
        }
    }

    /**
    * Get menu item by item id
    */
    public async Task<MenuItemDBModel> GetMenuItemById(string collectionName, string id)
    {
        try
        {
            // Init collection
            var collection = _categoriesDatabase.GetCollection<MenuItemDBModel>(collectionName);

            // Get the item
            var menuItem = await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return menuItem;
        }
        catch (Exception e)
        {
            throw new DatabaseException(e.Message);
        }
    }

    /**
    * Delete menu item by item id
    */
    public async Task<Unit> DeleteMenuItemById(string collectionName, string id)
    {
        try
        {
            // Init collection
            var collection = _categoriesDatabase.GetCollection<MenuItemDBModel>(collectionName);

            // Delete the item
            await collection.DeleteOneAsync(x => x.Id == id);
            return Unit.Value;
        }
        catch (Exception e)
        {
            throw new DatabaseException(e.Message);
        }
    }
}