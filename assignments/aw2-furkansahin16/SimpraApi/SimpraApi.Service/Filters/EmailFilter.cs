namespace SimpraApi.Service.Filters;

public class EmailFilter : ActionFilterAttribute
{
    private readonly SimpraDbContext Context;
    private readonly DbSet<Staff> Table;
    public EmailFilter(SimpraDbContext context)
    {
        this.Context = context;
        Table = this.Context.Set<Staff>();
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionDescriptor.Parameters.Any(x => x.Name == "request"))
        {
            if (context.HttpContext.Request.Method == "POST")
            {
                var request = context.ActionArguments["request"] as StaffCreateRequest;
                context.Result = CheckIfMailExist(request!.Email);
            }
            else if (context.HttpContext.Request.Method == "PUT")
            {
                var request = context.ActionArguments["request"] as StaffUpdateRequest;
                var staff = this.Table.Find(request!.Id);
                if (staff!.Email != request.Email.ToLower())
                {
                    context.Result = CheckIfMailExist(request!.Email);
                }
            }
        }
    }

    private ObjectResult? CheckIfMailExist(string email)
    {
        email = email.ToLower();
        return this.Table.Any(x => x.Email == email)
            ? new ObjectResult(new ErrorResponse(String.Format(Messages.EmailError, email), HttpStatusCode.Forbidden))
            : default;
    }
}
