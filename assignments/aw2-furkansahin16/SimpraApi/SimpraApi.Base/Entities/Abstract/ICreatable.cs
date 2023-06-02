namespace SimpraApi.Base;

public interface ICreatable : IEntity
{
    string? CreatedBy { get; set; }
    DateTime CreatedAt { get; set; }
}
