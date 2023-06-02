using Microsoft.AspNetCore.Mvc;

namespace SimpraApi.Infrastructure;

public class ValidationFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var result = new ErrorResponse(Messages.Error.Validation, HttpStatusCode.BadRequest);
            result.Errors = context.ModelState.Values
                .SelectMany(modelState => modelState.Errors)
                .Select(error => error.ErrorMessage)
                .ToList();

            Log.Error(
                    $"Method={context.HttpContext.Request.Method} || " +
                    $"Path={context.HttpContext.Request.Path} || " +
                    "Exception= Access was requested without authentication. || " +
                    $"Errors= {result.Errors.ToJson()}"
                    );

            context.Result = new ObjectResult(result);
        }
    }
}
