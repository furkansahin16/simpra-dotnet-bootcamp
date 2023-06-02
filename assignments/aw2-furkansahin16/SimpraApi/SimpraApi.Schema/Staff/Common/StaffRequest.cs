namespace SimpraApi.Schema;
public abstract class StaffRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string DateOfBirth { get; set; } = null!;
    public string? AddressLine { get; set; }
    public string? City { get; set; }
    public string Country { get; set; } = null!;
    public string? Province { get; set; }
}
