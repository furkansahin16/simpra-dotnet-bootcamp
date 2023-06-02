using System.Net;

namespace SimpraApi.Base.Utilities.Results;

public abstract class CommonDataResponse<T> : CommonResponse, IDataResponse<T>
    where T : class
{
    public T Data { get; set; } = null!;
    public CommonDataResponse(bool isSuccess, T data) : base(isSuccess) => this.Data = data;
    public CommonDataResponse(bool isSuccess, T data, string message) : base(isSuccess, message) => this.Data = data;
    public CommonDataResponse(bool isSuccess, T data, string message, HttpStatusCode statusCode) : base(isSuccess, message, statusCode) => this.Data = data;
}
