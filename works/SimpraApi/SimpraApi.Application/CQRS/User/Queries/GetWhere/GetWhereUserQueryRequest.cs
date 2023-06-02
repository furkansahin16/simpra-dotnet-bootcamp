namespace SimpraApi.Application;

public class GetWhereUserQueryRequest : GetWhereQueryRequest
{
    public string? Status { get; set; }
    public string? Role { get; set; }
}