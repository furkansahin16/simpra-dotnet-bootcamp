using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;


namespace SimpraApi.Infrastructure;
public class CustomAuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public CustomAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
        {
            var role = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            var response = new ObjectResult(new ErrorResponse(Messages.Unauthorized.Format(role?.ToString() ?? "undefined-role"), HttpStatusCode.Unauthorized));
            var json = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync(json);
            return;
        }
        await _next(context);
    }
}
