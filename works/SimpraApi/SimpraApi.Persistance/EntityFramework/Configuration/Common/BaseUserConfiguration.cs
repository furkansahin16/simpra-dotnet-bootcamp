namespace SimpraApi.Persistance.EntityFramework;

public class BaseUserConfiguration<TEntity> : SoftDeletableEntityConfiguration<TEntity> where TEntity : BaseUser
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(64);
        builder.Property(x => x.Role).IsRequired().HasMaxLength(15);
        builder.Property(x => x.PasswordRetryCount).IsRequired().HasDefaultValue(0);

        builder.HasIndex(x => x.Email).IsUnique();
    }
}
