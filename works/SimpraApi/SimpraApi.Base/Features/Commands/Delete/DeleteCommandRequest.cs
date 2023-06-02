namespace SimpraApi.Base;
public abstract class DeleteCommandRequest : IRequest<IResponse>
{
    public string Id { get; set; } = null!;
}
