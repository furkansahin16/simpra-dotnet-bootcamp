using System.Text.Json.Serialization;

namespace SimpraApi.Application;
public class ProductDto : EntityResponse
{
    public string Name { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Tag { get; set; } = null!;

    [JsonIgnore]
    public string CategoryId { get; set; } = null!;
    public CategoryDto Category { get; set; } = null!;
}
