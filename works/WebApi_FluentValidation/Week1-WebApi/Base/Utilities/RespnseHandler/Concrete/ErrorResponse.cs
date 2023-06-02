using Week1_WebApi.Base.Utilities.RespnseHandler.Concrete.Common;

namespace Week1_WebApi.Base.Utilities.RespnseHandler.Concrete;

public class ErrorResponse : CommonResponse
{
    public List<string> Errors { get; set; } = new(); 
    public ErrorResponse(string message) : base(false, message) { }
    public ErrorResponse() : base(false) { }
}
