using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace SimpraApi.Service;

public static class FluentValidationExtension
{
    public static IServiceCollection AddFluentValidationExtension(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(cfg => cfg.SuppressModelStateInvalidFilter = true);
        services
            .AddFluentValidationAutoValidation(opt => opt.DisableDataAnnotationsValidation = true)
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }

}
