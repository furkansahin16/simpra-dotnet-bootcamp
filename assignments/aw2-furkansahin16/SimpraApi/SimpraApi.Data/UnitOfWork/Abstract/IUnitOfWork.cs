namespace SimpraApi.Data;
public interface IUnitOfWork : IDisposable
{
    Task<IResponse?> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<IResponse?> SaveChangesAsyncWithTransaction(CancellationToken cancellationToken = default);
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
}
