using MongoDB.Driver;
using Categories.API.v1.Model;
using Categories.API.Configuration;

namespace Categories.API.v1.DBRepo;

public interface IMongoDBRepository
{
    public Task CreateMenuItem(string collectionName, MenuItem category);
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

    public async Task CreateMenuItem(string collectionName, MenuItem menuItem)
    {
        // Init collection
        var collection = _categoriesDatabase.GetCollection<MenuItem>(collectionName);

        // Insert the menu item
        await collection.InsertOneAsync(menuItem);
    }
}