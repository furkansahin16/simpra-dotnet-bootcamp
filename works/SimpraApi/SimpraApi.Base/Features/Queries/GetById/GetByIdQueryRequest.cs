namespace SimpraApi.Base;
public abstract class GetByIdQueryRequest : IRequest<IResponse>
{
    public string Id { get; set; }
}