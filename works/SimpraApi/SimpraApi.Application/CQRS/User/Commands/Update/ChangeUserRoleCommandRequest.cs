namespace SimpraApi.Application;

public class ChangeUserRoleCommandRequest : UpdateCommandRequest
{
	public string Role { get; set; } = null!;
}
