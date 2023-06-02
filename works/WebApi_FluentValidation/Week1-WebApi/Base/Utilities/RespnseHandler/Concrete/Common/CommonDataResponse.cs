using Week1_WebApi.Base.Utilities.RespnseHandler.Abstract;

namespace Week1_WebApi.Base.Utilities.RespnseHandler.Concrete.Common;

public abstract class CommonDataResponse<T> : CommonResponse, ICommonDataResponse<T> where T : class
{
    public T Data { get; set; } = null!;

    public CommonDataResponse(bool isSuccess, T data) : base(isSuccess) => Data = data;
    public CommonDataResponse(bool isSuccess, T data, string message) : base(isSuccess, message) => Data = data;
}
