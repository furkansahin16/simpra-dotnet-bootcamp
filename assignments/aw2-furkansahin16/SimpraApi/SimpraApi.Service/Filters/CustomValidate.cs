namespace SimpraApi.Service.Filters;

public class CustomValidate : ActionFilterAttribute
{
    private readonly Type _validatorType;

    public CustomValidate(Type validatorType)
    {
        this._validatorType = validatorType;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionDescriptor.Parameters.Any(x => x.Name == "request"))
        {
            var validator = (IValidator)Activator.CreateInstance(this._validatorType)!;

            if (!context.ActionArguments.ContainsKey("request"))
            {
                context.Result = new BadRequestResult();
                return;
            }

            var model = context.ActionArguments["request"];

            var validationContext = new ValidationContext<object>(model!);

            var validationResult = validator.Validate(validationContext);

            if (!validationResult.IsValid)
            {
                var response = new ErrorResponse("ValidationError", HttpStatusCode.Forbidden);
                if (validationResult.Errors.Any(x => x.PropertyName == "NullObject"))
                {
                    context.Result = new BadRequestResult();
                }
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                context.Result = new ObjectResult(response);
            }
        }
    }
}

