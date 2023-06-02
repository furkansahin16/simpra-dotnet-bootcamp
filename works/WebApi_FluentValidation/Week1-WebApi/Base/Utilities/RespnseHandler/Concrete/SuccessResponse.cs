using Week1_WebApi.Base.Utilities.RespnseHandler.Concrete.Common;

namespace Week1_WebApi.Base.Utilities.RespnseHandler.Concrete;

public class SuccessResponse : CommonResponse
{
    public SuccessResponse(string message) : base(true, message) { }
    public SuccessResponse() : base(true) { }
}
