
namespace SimpraApi.Application;
public interface ITokenService
{
    string GenerateToken(Claim[] claims);
}
