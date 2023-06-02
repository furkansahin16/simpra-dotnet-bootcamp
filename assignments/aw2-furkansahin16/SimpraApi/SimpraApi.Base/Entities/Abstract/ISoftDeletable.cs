namespace SimpraApi.Base;

public interface ISoftDeletable : IEntity
{
    string? DeletedBy { get; set; }
    DateTime DeletedAt { get; set; }
}
