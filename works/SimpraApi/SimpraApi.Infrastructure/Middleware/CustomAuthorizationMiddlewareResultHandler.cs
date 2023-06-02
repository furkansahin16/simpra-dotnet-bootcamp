using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using System.Security.Claims;

namespace SimpraApi.Infrastructure;
public class CustomAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
{
    private readonly AuthorizationMiddlewareResultHandler defaultHandler = new();
    public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
    {
        if (!authorizeResult.Succeeded)
        {
            IResponse response;
            if (context.User.Identity!.IsAuthenticated)
            {
                response = new ErrorResponse(Messages.Unauthorized.Format(context.User.Claims.First(x => x.Type == ClaimTypes.Role).Value), HttpStatusCode.Unauthorized);
                Log.Warning(
                    $"User={context.User.Claims.First(x => x.Type == ClaimTypes.Email).Value} || " +
                    $"Role={context.User.Claims.Select(x => x.Type == ClaimTypes.Role).ToArray()} || " +
                    $"Method={context.Request.Method} || " +
                    $"Path={context.Request.Path} || " +
                    "Exception= An unauthorized access has been requested."
                );
            }
            else
            {
                response = new ErrorResponse(Messages.Unauthenticate, HttpStatusCode.Unauthorized);
                Log.Warning(
                    $"Method={context.Request.Method} || " +
                    $"Path={context.Request.Path} || " +
                    "Exception= Access was requested without authentication."
                    );
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(response);
            return;
        }
        await defaultHandler.HandleAsync(next, context, policy, authorizeResult);
    }
}

