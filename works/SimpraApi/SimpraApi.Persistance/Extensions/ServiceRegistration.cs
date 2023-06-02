using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpraApi.Persistance.EntityFramework;

namespace SimpraApi.Persistance;
public static class ServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
    {
        services
            .AddContextService(configuration)
            .AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
    private static IServiceCollection AddContextService(this IServiceCollection services,IConfiguration configuration)
    {
        string? dbType = configuration.GetConnectionString("DbType");

        if (string.IsNullOrEmpty(dbType)) throw new ArgumentException(Messages.Error.DbType);

        string? dbConfig = configuration.GetConnectionString(dbType);

        if (string.IsNullOrEmpty(dbConfig)) throw new ArgumentException(Messages.Error.ConnectionString);

        services.AddDbContext<SimpraDbContext>(opt =>
        {
            _ = dbType switch
            {
                "MsSql" => opt.UseSqlServer(dbConfig, cfg => cfg.EnableRetryOnFailure()),
                "PostgreSql" => opt.UseNpgsql(dbConfig, cfg => cfg.EnableRetryOnFailure()),
                _ => throw new ArgumentException(Messages.Error.DbType)
            };
        });

        return services;
    }
}
