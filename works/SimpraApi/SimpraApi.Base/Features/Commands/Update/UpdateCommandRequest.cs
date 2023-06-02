namespace SimpraApi.Base;
public abstract class UpdateCommandRequest : IRequest<IResponse>
{
    public string Id { get; set; } = null!;
}
