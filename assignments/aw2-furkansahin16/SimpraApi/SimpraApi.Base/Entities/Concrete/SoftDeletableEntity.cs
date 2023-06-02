namespace SimpraApi.Base;

public abstract class SoftDeletableEntity : AuditableEntity, ISoftDeletable
{
    public DateTime DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}
