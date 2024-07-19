using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Categories.API.MongoDBModel;

namespace Categories.API.v1.Model;

public class AddMenuItemReqModel
{
    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    [Required]
    [JsonPropertyName("owner")]
    public string Owner { get; set; } = string.Empty;
    [Required]
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("steps")]
    public List<string>? Steps { get; set; }
    [JsonPropertyName("imgUrl")]
    public string? ImgUrl { get; set; }
}

public class GetMenuItemsReqModel
{
    [Required]
    public string Owner { get; set; } = string.Empty;
    [Required]
    public int Page { get; set; }
}

public class GetMenuItemsResModel
{
    public List<MenuItemDBModel>? MenuItems { get; set; }
}