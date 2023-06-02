namespace SimpraApi.Base;
public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).ValueGeneratedOnAdd();
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.CreatedBy).HasMaxLength(36).IsRequired(false);

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();
    }
}
