using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Categories.API.MongoDBModel;

public class MenuItemDBModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;
    [BsonElement("description")]
    public string Description { get; set; } = string.Empty;
    [BsonElement("owner")]
    public string Owner { get; set; } = string.Empty;
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }
    [BsonElement("steps")]
    public List<string>? Steps { get; set; }
    [BsonElement("imgUrl")]
    public string? ImgUrl { get; set; }
}