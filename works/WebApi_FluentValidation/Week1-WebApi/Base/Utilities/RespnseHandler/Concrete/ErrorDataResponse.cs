using Week1_WebApi.Base.Utilities.RespnseHandler.Concrete.Common;

namespace Week1_WebApi.Base.Utilities.RespnseHandler.Concrete;

public class ErrorDataResponse<T> : CommonDataResponse<T> where T : class
{
    public ErrorDataResponse(T data) : base(false, data) { }
    public ErrorDataResponse(T data, string message) : base(false, data, message) { }
}
