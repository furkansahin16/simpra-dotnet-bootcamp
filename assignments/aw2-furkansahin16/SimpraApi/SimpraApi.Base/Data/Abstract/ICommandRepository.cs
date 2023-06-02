namespace SimpraApi.Base;
public interface ICommandRepository<TEntity> where TEntity : BaseEntity
{
    Task DeleteAsync(TEntity entity);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
}


