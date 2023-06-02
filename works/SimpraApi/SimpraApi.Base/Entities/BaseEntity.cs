namespace SimpraApi.Base;
public abstract class BaseEntity : IEntity
{
    public Guid Id { get; set; }
    public string Status { get; set; } = null!;
    public virtual string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}
