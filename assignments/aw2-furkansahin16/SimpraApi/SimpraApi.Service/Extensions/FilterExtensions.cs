namespace SimpraApi.Service;
public static class FilterExtensions
{
    public static IServiceCollection AddFiltersExtensions(this IServiceCollection services)
    {
        services.AddScoped<NotFoundFilter>();
        services.AddScoped<EmailFilter>();
        services.AddScoped<CacheResourceFilter>();
        return services;
    }
}
