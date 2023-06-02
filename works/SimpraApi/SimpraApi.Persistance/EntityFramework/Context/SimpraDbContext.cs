using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpraApi.Persistance.SeedData;
using System.Security.Claims;

namespace SimpraApi.Persistance.EntityFramework;
public class SimpraDbContext : DbContext
{
    private readonly IHttpContextAccessor? _contextAccessor;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Product> Category { get; set; } = null!;
    public DbSet<User> User { get; set; } = null!;
    public SimpraDbContext(DbContextOptions<SimpraDbContext> options) : base(options) { }
    public SimpraDbContext(DbContextOptions<SimpraDbContext> options, IHttpContextAccessor contextAccessor) : base(options) => _contextAccessor = contextAccessor;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);

        var seedData = DummyDataGenerator.GenerateDummyData(10, 50);
        modelBuilder.Entity<Category>().HasData(seedData["Category"]);
        modelBuilder.Entity<Product>().HasData(seedData["Product"]);
        modelBuilder.Entity<User>().HasData(seedData["User"]);

        base.OnModelCreating(modelBuilder);
    }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await SetBaseProperties();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private async Task SetBaseProperties()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        var user = await GetUserFromRequest();
        var userName = user is null ? "not-user" : user.Email;
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added: SetAddedEntity(entry, userName); break;
                case EntityState.Modified: SetModifiedEntity(entry, userName); break;
                case EntityState.Deleted: SetDeletedEntity(entry, userName); break;
            }
        }
    }

    private async Task<User?> GetUserFromRequest()
    {
        var userId = _contextAccessor?.HttpContext?.User.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId is not null)
        {
            var user = await User.FindAsync(Guid.Parse(userId));
            user!.LastActivity = DateTime.UtcNow;
            return user;
        }
        return null;
    }

    private void SetDeletedEntity(EntityEntry<BaseEntity> entry, string user)
    {
        Log.Information("{@entity} is deleted by {@user}", entry.Entity, user);
        if (entry.Entity is not SoftDeletableEntity entity) return;
        entity.DeletedBy = user;
        entity.Status = Status.Deleted;
        entry.State = EntityState.Modified;
        entity.DeletedAt = DateTime.UtcNow;
    }

    private void SetModifiedEntity(EntityEntry<BaseEntity> entry, string user)
    {
        if (entry.Entity is not AuditableEntity entity)
        {
            entry.State = EntityState.Detached;
            return;
        }
        else if (entity is not BaseUser)
        {
            entity.Status = Status.Updated;
        }
        entity.UpdatedBy = user;
        entity.UpdatedAt = DateTime.UtcNow;
        Log.Information("{@entity} is updated by {@user}", entry.Entity, user);
    }

    private void SetAddedEntity(EntityEntry<BaseEntity> entry, string user)
    {
        if (entry.Entity is BaseUser baseUser)
        {
            baseUser.LastActivity = DateTime.UtcNow;
            baseUser.Status = Status.Active;
        }
        else
        {
            entry.Entity.Status = Status.Added;
            entry.Entity.CreatedBy = user;
        }
        entry.Entity.CreatedAt = DateTime.UtcNow;
        Log.Information("{@entity} is created by {@user}", entry.Entity, user);
    }
}
