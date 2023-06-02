using System.ComponentModel.DataAnnotations.Schema;

namespace SimpraApi.Base;

public abstract class BaseUser : SoftDeletableEntity, IPerson
{
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public byte[] Password { get; set; } = null!;
    public int PasswordRetryCount { get; set; }
    public DateTime LastActivity { get; set; }
    public string Role { get; set; } = Roles.Standart;
    [NotMapped] public override string? CreatedBy => null;
    [NotMapped] public override string? UpdatedBy => null;
    [NotMapped] public override string? DeletedBy => null;
    [NotMapped] public string FullName => FirstName + " " + LastName;

    public override string ToString() => base.ToString() + $" || Email= {this.FullName}";
}
