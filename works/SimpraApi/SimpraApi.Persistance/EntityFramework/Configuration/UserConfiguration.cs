namespace SimpraApi.Persistance.EntityFramework;

public class UserConfiguration : BaseUserConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
    }
}
