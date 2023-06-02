using SimpraApi.Base;

namespace SimpraApi.Schema;
public class StaffResponse : IBaseResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string DateOfBirth { get; set; } = null!;
    public string? AddressLine { get; set; }
    public string? City { get; set; }
    public string Country { get; set; } = null!;
    public string? Province { get; set; }
    public string CreatedBy { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public string Status { get; set; } = null!;
}
