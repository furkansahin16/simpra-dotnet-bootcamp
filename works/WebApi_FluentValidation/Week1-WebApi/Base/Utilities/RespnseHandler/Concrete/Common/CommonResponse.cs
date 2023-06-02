using Week1_WebApi.Base.Utilities.RespnseHandler.Abstract;

namespace Week1_WebApi.Base.Utilities.RespnseHandler.Concrete.Common;

public abstract class CommonResponse : ICommonResponse
{
    public bool IsSuccess { get; protected set; } = true;
    public string Message { get; protected set; }

    public CommonResponse(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }
    public CommonResponse(bool isSuccess) : this(isSuccess, isSuccess ? "Success" : "Error") { }
}
