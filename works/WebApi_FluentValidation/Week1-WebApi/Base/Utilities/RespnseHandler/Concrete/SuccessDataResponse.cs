using Week1_WebApi.Base.Utilities.RespnseHandler.Concrete.Common;

namespace Week1_WebApi.Base.Utilities.RespnseHandler.Concrete;

public class SuccessDataResponse<T> : CommonDataResponse<T> where T : class
{
    public SuccessDataResponse(T data) : base(true, data) { }
    public SuccessDataResponse(T data, string message) : base(true, data, message) { }
}
