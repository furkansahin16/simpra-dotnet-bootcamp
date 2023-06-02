namespace SimpraApi.Base;
public interface IRepository<TEntity> : ICommandRepository<TEntity>,IQueryRepository<TEntity> where TEntity : BaseEntity
{
}
