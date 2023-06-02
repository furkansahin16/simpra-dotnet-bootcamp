using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SimpraApi.Service;
public static class JwtExtension
{
    public static IServiceCollection AddJwtExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.RequireHttpsMetadata = true;
            opt.SaveToken = true;
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = configuration["JwtConfig:Issuer"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtConfig:Secret"])),
                ValidAudience = configuration["JwtConfig:Audience"],
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(2)
            };
        });

        services.AddAuthorization(opt =>
        {
            opt.AddPolicy(Policies.AdminOrManager, policy => policy.RequireRole(Roles.Admin, Roles.Manager));
            opt.AddPolicy(Policies.AllUser, policy => policy.RequireAuthenticatedUser());
        });

        return services;
    }
}
