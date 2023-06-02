namespace SimpraApi.Application;

public class UserDetailDto : UserDto
{
    public string Role { get; set; } = null!;
    public DateTime LastActivity { get; set; }
}
