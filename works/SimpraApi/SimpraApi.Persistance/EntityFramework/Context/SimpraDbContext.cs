using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpraApi.Persistance.SeedData;
using System.Security.Claims;

namespace SimpraApi.Persistance.EntityFramework;
public class SimpraDbContext : DbContext
{
    private readonly IHttpContextAccessor? _contextAccessor;
    private string CurrentUser = string.Empty;
    private string UserIdentifier = string.Empty;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Product> Category { get; set; } = null!;
    public DbSet<User> User { get; set; } = null!;
    public SimpraDbContext(DbContextOptions<SimpraDbContext> options) : base(options) { }
    public SimpraDbContext(DbContextOptions<SimpraDbContext> options, IHttpContextAccessor contextAccessor) : base(options)
    {
        _contextAccessor = contextAccessor;
        GetUserFromRequest();
    }

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
        SetBaseProperties();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetBaseProperties()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added: SetAddedEntity(entry); break;
                case EntityState.Modified: SetModifiedEntity(entry); break;
                case EntityState.Deleted: SetDeletedEntity(entry); break;
            }
        }
    }

    private void GetUserFromRequest()
    {
        User? user = null;
        var userId = _contextAccessor?.HttpContext?.User.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId is not null)
        {
            user = User.Find(Guid.Parse(userId));
            user!.LastActivity = DateTime.UtcNow;
        }
        this.CurrentUser = user?.ToString() ?? "system";
        this.UserIdentifier = user?.Email ?? "system";
    }

    private void SetDeletedEntity(EntityEntry<BaseEntity> entry)
    {
        Log.Information(Messages.Log.EntityDeleted, entry.Entity.ToString(), CurrentUser.ToString());
        if (entry.Entity is not SoftDeletableEntity entity) return;
        entity.DeletedBy = UserIdentifier;
        entity.Status = Status.Deleted;
        entry.State = EntityState.Modified;
        entity.DeletedAt = DateTime.UtcNow;
    }

    private void SetModifiedEntity(EntityEntry<BaseEntity> entry)
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
        Log.Information(Messages.Log.EntityUpdated, entry.Entity.ToString(), CurrentUser.ToString());
        entity.UpdatedBy = UserIdentifier;
        entity.UpdatedAt = DateTime.UtcNow;
    }

    private void SetAddedEntity(EntityEntry<BaseEntity> entry)
    {
        if (entry.Entity is BaseUser baseUser)
        {
            baseUser.LastActivity = DateTime.UtcNow;
            baseUser.Status = Status.Active;
            Log.Information(Messages.Log.UserSignedUp, entry.Entity.ToString());
        }
        else
        {
            entry.Entity.Status = Status.Added;
            Log.Information(Messages.Log.EntityCreated, entry.Entity.ToString(), CurrentUser.ToString());
        }
        entry.Entity.CreatedBy = UserIdentifier;
        entry.Entity.CreatedAt = DateTime.UtcNow;
    }
}
