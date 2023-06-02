using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SimpraApi.Data;

public static class DataExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        var dbTypeError = new ArgumentException("Invalid Db Type");
        var connectionStringError = new ArgumentException("Connection string not found for the given Db Type");

        string? dbType = configuration.GetConnectionString("DbType");

        if (dbType is null) throw dbTypeError;

        string? dbConfig = dbType switch
        {
            "MsSql" => configuration.GetConnectionString("MsSql"),
            "PostgreSql" => configuration.GetConnectionString("PostgreSql"),
            _ => throw dbTypeError
        };

        if (dbConfig is null) throw connectionStringError;

        services.AddDbContext<SimpraDbContext>(opt =>
        {
            _ = dbType switch
            {
                "MsSql" => opt.UseSqlServer(dbConfig,opt=>opt.EnableRetryOnFailure()),
                "PostgreSql" => opt.UseNpgsql(dbConfig,opt=>opt.EnableRetryOnFailure()),
                _ => throw dbTypeError
            };
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

