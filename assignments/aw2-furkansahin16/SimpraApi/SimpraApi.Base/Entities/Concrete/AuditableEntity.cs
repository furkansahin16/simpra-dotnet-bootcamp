namespace SimpraApi.Base;

public abstract class AuditableEntity : BaseEntity, IUpdatable
{
    public string? UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
}
