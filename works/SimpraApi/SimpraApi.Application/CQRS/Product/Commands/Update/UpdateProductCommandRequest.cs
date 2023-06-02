namespace SimpraApi.Application;

public class UpdateProductCommandRequest : UpdateCommandRequest
{
    public string Name { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Tag { get; set; } = null!;
    public string? CategoryId { get; set; }
}
