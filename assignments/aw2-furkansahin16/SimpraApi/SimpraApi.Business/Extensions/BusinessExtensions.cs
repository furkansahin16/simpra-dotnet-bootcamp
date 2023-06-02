using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpraApi.Business.Services;

namespace SimpraApi.Business;
public static class BusinessExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDataServices(configuration)
            .AddMapperServices();

        services.AddScoped<IStaffService, StaffService>();

        return services;
    }
}
