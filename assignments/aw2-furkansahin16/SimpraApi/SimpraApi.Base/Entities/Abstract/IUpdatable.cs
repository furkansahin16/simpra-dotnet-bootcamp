namespace SimpraApi.Base;

public interface IUpdatable : IEntity
{
    string? UpdatedBy { get; set; }
    DateTime UpdatedAt { get; set; }
}
