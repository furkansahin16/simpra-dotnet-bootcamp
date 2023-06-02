using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SimpraApi.Schema;

public static class MapperExtension
{
    public static IServiceCollection AddMapperServices(this IServiceCollection services)
    {
        services.AddSingleton(opt =>
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddMaps(Assembly.GetExecutingAssembly());
            });
            return mapperConfig.CreateMapper();
        });
        return services;
    }
}
