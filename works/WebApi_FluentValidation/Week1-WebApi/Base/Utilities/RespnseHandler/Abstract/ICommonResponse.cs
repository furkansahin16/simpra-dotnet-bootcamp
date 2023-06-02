namespace Week1_WebApi.Base.Utilities.RespnseHandler.Abstract;

public interface ICommonResponse
{
    bool IsSuccess { get; }
    string Message { get; }
}
