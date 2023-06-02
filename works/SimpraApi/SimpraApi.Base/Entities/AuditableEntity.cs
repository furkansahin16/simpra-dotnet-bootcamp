namespace SimpraApi.Base;

public abstract class AuditableEntity : BaseEntity
{
    public virtual string? UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
}
