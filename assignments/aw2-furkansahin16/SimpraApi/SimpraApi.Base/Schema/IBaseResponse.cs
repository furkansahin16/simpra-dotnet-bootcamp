namespace SimpraApi.Base;
public interface IBaseResponse
{
    int Id { get; set; }
    string CreatedBy { get; set; }
    string CreatedAt { get; set; }
    string Status { get; set; }
}
