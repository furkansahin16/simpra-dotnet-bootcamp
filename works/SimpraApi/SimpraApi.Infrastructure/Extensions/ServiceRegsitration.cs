using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace SimpraApi.Infrastructure;
public static class ServiceRegsitration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddScoped<CacheResourceFilter>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddSingleton<IAuthorizationMiddlewareResultHandler, CustomAuthorizationMiddlewareResultHandler>();
        return services;
    }
}
