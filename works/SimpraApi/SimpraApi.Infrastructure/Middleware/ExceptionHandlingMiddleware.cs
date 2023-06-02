using Microsoft.AspNetCore.Diagnostics;

namespace SimpraApi.Infrastructure;
public class ExceptionHandlingMiddleware
{
    public ExceptionHandlingMiddleware(RequestDelegate next) { }

    public async Task InvokeAsync(HttpContext context)
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
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
