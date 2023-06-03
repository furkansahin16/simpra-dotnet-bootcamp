namespace SimpraApi.Application;

public class GetWhereProductQueryRequest : GetWhereQueryRequest
{
    public string? Name { get; set; }
    public string? CategoryId { get; set; }
}