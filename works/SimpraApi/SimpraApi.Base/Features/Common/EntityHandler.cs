
namespace SimpraApi.Base;
public abstract class EntityHandler<TEntity> where TEntity : BaseEntity
{
    protected readonly IRepository<TEntity> Repository;
    protected readonly IUnitOfWork UnitOfWork;
    public EntityHandler(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
        Repository = UnitOfWork.GetRepository<TEntity>();
    }
    protected bool TryToGetById(string id, out IResponse? response)
    {
        Entity = Repository.Find(Guid.Parse(id), Includes);
        response = Entity is null ?
            new ErrorResponse(Messages.Error.Get.Format(typeof(TEntity).Name,id), HttpStatusCode.NotFound) :
            null;
        return Entity is not null;
    }
    public Expression<Func<TEntity, object>>[]? Includes { get; protected set; }
    public TEntity? Entity { get; protected set; }
}
