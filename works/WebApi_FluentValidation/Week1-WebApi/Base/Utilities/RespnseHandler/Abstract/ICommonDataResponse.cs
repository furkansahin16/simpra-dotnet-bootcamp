namespace Week1_WebApi.Base.Utilities.RespnseHandler.Abstract;

public interface ICommonDataResponse<T> : ICommonResponse where T : class
{
    T Data { get; }
}
