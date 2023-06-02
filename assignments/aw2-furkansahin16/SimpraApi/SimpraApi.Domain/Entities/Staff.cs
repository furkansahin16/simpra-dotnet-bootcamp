using SimpraApi.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpraApi.Domain;

[Table("Staff",Schema ="dbo")]
public class Staff : SoftDeletableEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!; 
    public DateTime DateOfBirth { get; set; }
    public string? AddressLine { get; set; }
    public string? City { get; set; }
    public string Country { get; set; } = null!;
    public string? Province { get; set; }
    [NotMapped] public string? FullName => $"{FirstName} {LastName}";

}
