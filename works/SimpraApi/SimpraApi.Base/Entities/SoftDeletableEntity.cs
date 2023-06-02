namespace SimpraApi.Base;

public abstract class SoftDeletableEntity : AuditableEntity
{
    public virtual string? DeletedBy { get; set; }
    public DateTime DeletedAt { get; set; }
}
