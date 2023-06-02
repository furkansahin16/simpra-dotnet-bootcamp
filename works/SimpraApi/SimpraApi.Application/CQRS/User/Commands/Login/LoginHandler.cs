using Microsoft.Extensions.Options;

namespace SimpraApi.Application;
public class LoginHandler : IRequestHandler<LoginRequest, IResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtConfig _jwtConfig;
    private readonly ITokenService _tokenService;
    public LoginHandler(IUnitOfWork unitOfWork, IOptions<JwtConfig> jwtConfig, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _jwtConfig = jwtConfig.Value;
        _tokenService = tokenService;
    }

    public async Task<IResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        request.Password = request.Password.Trim();
        request.Email = request.Email.Trim().ToLower();

        var user = await _unitOfWork.GetRepository<User>().GetAsync(x => x.Email == request.Email);

        if (user is null || !request.Password.VerifyPassword(user.Password))
        {
            AddPasswordRetryError(user);
            return new ErrorResponse(Messages.TokenError, HttpStatusCode.BadRequest);
        }

        if (user.Status == Status.Blocked)
            return new ErrorResponse(Messages.Blocked, HttpStatusCode.Forbidden);

        user.LastActivity = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();

        string token = _tokenService.GenerateToken(GetClaims(user));
        return new SuccessDataResponse<AuthResult>(new AuthResult(user.Email, token, TimeSpan.FromMinutes(_jwtConfig.AccessTokenExpiration).ToString()));
    }

    private Claim[] GetClaims(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Role,user.Role),
            new Claim(ClaimTypes.Role,user.Role),
            new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
            new Claim("FirstName",user.FirstName),
            new Claim("LastName",user.LastName),
            new Claim("Status",user.Status.ToString()),
            new Claim("LastActivity",user.LastActivity.ToString())
        };

        return claims;
    }

    private async void AddPasswordRetryError(User? user)
    {
        if (user is not null && user.Status != Status.Blocked)
        {
            user.PasswordRetryCount++;
            if (user.PasswordRetryCount == 3) user.Status = Status.Blocked;
            await _unitOfWork.GetRepository<User>().UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
