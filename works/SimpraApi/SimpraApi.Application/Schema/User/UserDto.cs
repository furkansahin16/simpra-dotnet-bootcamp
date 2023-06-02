namespace SimpraApi.Application;
public class UserDto : EntityResponse
{
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
}