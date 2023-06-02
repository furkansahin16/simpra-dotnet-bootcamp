namespace SimpraApi.Base;
public class EfRepository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _table;

    public EfRepository(DbContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }
    public async Task AddAsync(TEntity entity)
    {
        await _table.AddAsync(entity);
    }
    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _table.AddRangeAsync(entities);
    }
    public async Task UpdateAsync(TEntity entity)
    {
        await Task.FromResult(_table.Update(entity));
    }
    public Task DeleteAsync(TEntity entity) => Task.FromResult(_table.Remove(entity));
    public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true) => await GetAllActives(tracking).ToListAsync();
    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true) => await GetAllActives(tracking).Where(filter).ToListAsync();
    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true) => await GetAllActives(tracking).FirstOrDefaultAsync(expression);
    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null) => filter is null ? GetAllActives().AnyAsync() : GetAllActives().AnyAsync(filter);
    protected IQueryable<TEntity> GetAllActives(bool tracking = true)
    {
        var entites = _table.Where(x => x.Status != Status.Deleted);
        return tracking ? entites : entites.AsNoTracking();
    }

}