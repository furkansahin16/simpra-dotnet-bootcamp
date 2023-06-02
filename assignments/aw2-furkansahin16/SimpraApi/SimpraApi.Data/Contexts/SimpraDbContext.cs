using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;

namespace SimpraApi.Data;
public class SimpraDbContext : DbContext
{
    private readonly IHttpContextAccessor? _contextAccessor;
    public SimpraDbContext(DbContextOptions<SimpraDbContext> options,IHttpContextAccessor contextAccessor) : base(options) => _contextAccessor = contextAccessor;
	public SimpraDbContext(DbContextOptions<SimpraDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StaffConfiguration());
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Staff> Staff { get; set; } = null!;
    public override int SaveChanges()
    {
        SetBaseProperties();
        return base.SaveChanges();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetBaseProperties();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetBaseProperties()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        var user = _contextAccessor?.HttpContext.User.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? "admin";
        foreach(var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added: SetAddedEntity(entry, user); break;
                case EntityState.Modified: SetModifiedEntity(entry, user); break;
                case EntityState.Deleted: SetDeletedEntity(entry, user); break;
            }
        }
    }

    private void SetDeletedEntity(EntityEntry<BaseEntity> entry, string user)
    {
        if (entry.Entity is not SoftDeletableEntity entity) return;
        entry.State = EntityState.Modified;
        entity.Status = Status.Deleted;
        entity.DeletedBy = user;
        entity.DeletedAt= DateTime.UtcNow;
    }

    private void SetModifiedEntity(EntityEntry<BaseEntity> entry, string user)
    {
        if(entry.Entity is not AuditableEntity entity)
        {
            entry.State = EntityState.Detached;
            return;
        }
        entity.Status = Status.Updated;
        entity.UpdatedBy = user;
        entity.UpdatedAt = DateTime.UtcNow;
    }

    private void SetAddedEntity(EntityEntry<BaseEntity> entry,string user)
    {
        entry.Entity.Status= Status.Added;
        entry.Entity.CreatedBy = user;
        entry.Entity.CreatedAt = DateTime.UtcNow;
    }

}
