namespace SimpraApi.Base;
public interface IQueryRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true);
}


