namespace SimpraApi.Service.Filters;
public class NotFoundFilter : ActionFilterAttribute
{
    private readonly SimpraDbContext _context;
    private readonly IMemoryCache _memoryCache;
    private string _modelName = string.Empty;

    public NotFoundFilter(SimpraDbContext context, IMemoryCache memoryCache)
    {
        _context = context;
        _memoryCache = memoryCache;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        SetCacheKey(context, out string cacheKey, out this._modelName);
        int id;
        bool isBadRequest = false;

        switch (context.HttpContext.Request.Method)
        {
            case "GET":
            case "DELETE": GetIdFromPath(context, out isBadRequest, out id); break;
            case "PUT": GetIdFromBody(context, out isBadRequest, out id); break;
            default: return;
        }

        if (isBadRequest) context.Result = new ObjectResult(new ErrorResponse("Invalid id format!", HttpStatusCode.BadRequest));
        else if (_memoryCache.TryGetValue(cacheKey, out IEnumerable<IBaseResponse> data) &&
            string.Equals(context.HttpContext.Request.Method, "GET", StringComparison.OrdinalIgnoreCase))
        {
            context.Result = CheckFromCache(id, data);
        }
        else context.Result = CheckFromContext(id);
    }

    private ObjectResult CheckFromCache(int id, IEnumerable<IBaseResponse> data)
    {
        var entity = data.FirstOrDefault(x => x.Id == id);
        return (entity is null)
                 ? new ObjectResult(new ErrorResponse(String.Format(Messages.GetError, this._modelName, id), HttpStatusCode.NotFound))
                 : new ObjectResult(new SuccessDataResponse<object>(entity, String.Format(Messages.GetSuccess, this._modelName), HttpStatusCode.OK));
    }

    private ObjectResult? CheckFromContext(int id)
    {
        var entityType = _context.Model.GetEntityTypes().FirstOrDefault(x => x.ClrType.Name == this._modelName)!.ClrType;
        var dbSetMethod = typeof(DbContext).GetMethods().First(x => x.Name == "Set" && !x.GetParameters().Any()).MakeGenericMethod(entityType);
        var table = dbSetMethod.Invoke(_context, null);
        var findMethod = table!.GetType().GetMethods().First(x => x.Name == "Find");
        var entity = findMethod.Invoke(table, new object[] { new object[] { id } }) as BaseEntity;
        return (entity is null || entity.Status == Status.Deleted)
            ? new ObjectResult(new ErrorResponse(String.Format(Messages.GetError, this._modelName, id), HttpStatusCode.NotFound))
            : default;
    }

    private void GetIdFromBody(ActionExecutingContext context, out bool isBadRequest, out int id)
    {
        if (context.ActionArguments.ContainsKey("request"))
        {
            var request = context.ActionArguments["request"] as IBaseUpdateRequest;
            isBadRequest = request is null || request.Id < 0;
            id = request?.Id ?? default;
            return;
        }
        isBadRequest = true;
        id = default;
    }

    private void GetIdFromPath(ActionExecutingContext context, out bool isBadRequest, out int id)
    {
        if (context.ActionDescriptor.Parameters.Any(x => x.Name == "id") &&
            context.ActionArguments.Any(x => x.Key == "id"))
        {
            id = (int)context.ActionArguments["id"]!;
            isBadRequest = id < 0;
            return;
        }
        isBadRequest = true;
        id = default;
    }

    private void SetCacheKey(ActionExecutingContext context, out string cacheKey, out string modelName)
    {
        modelName = context.ActionDescriptor.RouteValues["controller"]!;
        cacheKey = $"{modelName}_Get";
    }
}
