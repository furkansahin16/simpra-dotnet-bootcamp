using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpraApi.Data.SeedData;

namespace SimpraApi.Data;

public class StaffConfiguration : SoftDeletableEntityConfiguration<Staff>
{
    public override void Configure(EntityTypeBuilder<Staff> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(64);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(15);
        builder.Property(x => x.DateOfBirth).IsRequired();
        builder.Property(x => x.Country).IsRequired().HasMaxLength(20);
        builder.Property(x => x.City).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.AddressLine).IsRequired(false).HasMaxLength(50);
        builder.Property(x => x.Province).IsRequired(false).HasMaxLength(30);

        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => new { x.LastName, x.Country });

        builder.HasData(DummyDataGenerator.GenerateDummyData(20));
    }
}
