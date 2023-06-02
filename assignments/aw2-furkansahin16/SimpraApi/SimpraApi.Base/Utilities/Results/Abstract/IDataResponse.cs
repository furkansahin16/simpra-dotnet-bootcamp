namespace SimpraApi.Base;

public interface IDataResponse<T> : IResponse where T : class
{
    T Data { get; }
}
