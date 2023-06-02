using Microsoft.AspNetCore.Diagnostics;
using SimpraApi.Infrastructure;
using System.Net;

namespace SimpraApi.Service;

public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration) => Configuration = configuration;
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(opt =>
        {
            opt.Filters.Add<ValidationFilter>();
            opt.Filters.Add<CacheResourceFilter>();
        });
        services.AddHttpContextAccessor();
        services
            .AddCustomSwaggerService()
            .AddJwtExtension(Configuration)
            .AddApplicationServices(Configuration)
            .AddPersistanceServices(Configuration)
            .AddInfrastructureServices();

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.DefaultModelExpandDepth(-1);
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simpra");
            c.DocumentTitle = "Simpra Api";
        });

        app.UseExceptionHandler(appConfig =>
        {
            appConfig.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var features = context.Features.Get<IExceptionHandlerFeature>();
                if (features is not null)
                {
                    Log.Fatal(
                        $"MethodName={features.Endpoint} || " +
                        $"Path={features.Path} || " +
                        $"Exception={features.Error}"
                        );
                    var response = new ErrorResponse(Messages.GeneralError, HttpStatusCode.InternalServerError);
                    await context.Response.WriteAsync(response.ToJson());
                }
            });
        });

        // TODO : Burayı kontrol et. Middleware çalışmıyor.
        //app.UseMiddleware<CustomAuthenticationMiddleware>();

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}