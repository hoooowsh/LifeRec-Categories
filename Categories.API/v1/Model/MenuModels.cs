using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Categories.API.v1.Model;

public class AddMenuItemRequestModel : MenuItem
{
    [Required]
    [JsonPropertyName("test")]
    public string Test { get; set; } = string.Empty;
}

public class MenuItem
{

    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public string Owner { get; set; } = string.Empty;
    public List<string>? Steps { get; set; }
    public string? ImgUrl { get; set; }
}