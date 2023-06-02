namespace SimpraApi.Application;

public class LoginRequest : IRequest<IResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
