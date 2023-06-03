using LinqKit;

namespace SimpraApi.Base;
public abstract class GetWhereQueryHandler<TEntity, TRequest, TResponse> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResponse>
    where TEntity : BaseEntity
    where TRequest : GetWhereQueryRequest
    where TResponse : EntityResponse
{
    protected readonly IMapper _mapper;
    public GetWhereQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork) => _mapper = mapper;
    public async virtual Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var expression = GetExpression(request);
        var entites = expression is null ?
            await Repository.GetAllAsync(false, Includes) :
            await Repository.GetAllAsync(expression, false, Includes);

        await UnitOfWork.SaveChangesAsync();

        return entites.Any()
            ? new SuccessDataResponse<EntityResponse>(_mapper.Map<List<TResponse>>(entites), Messages.Success.List.Format(typeof(TEntity).Name), HttpStatusCode.OK)
            : new ErrorResponse(Messages.Error.List.Format(typeof(TEntity).Name), HttpStatusCode.NoContent);
    }
    protected Expression<Func<TEntity, bool>>? GetExpression(TRequest request)
    {
        var filters = request.GetType().GetProperties();
        var predicate = PredicateBuilder.New<TEntity>();

        foreach (var filter in filters)
        {
            var value = filter.GetValue(request);
            if (value is not null)
            {
                var parameter = Expression.Parameter(typeof(TEntity));
                var propertyAccess = Expression.Property(parameter, filter.Name);
                Expression filterExpression;
                if (filter.PropertyType == typeof(string))
                {
                    var filterValue = Expression.Constant(value!.ToString()!.Trim().ToLower());
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    filterExpression = Expression.Call(propertyAccess, containsMethod!, filterValue);
                }
                else if (filter.PropertyType == typeof(int))
                {
                    var filterValue = Expression.Constant(value);
                    var equalsMethod = typeof(int).GetMethod("Equals", new[] { typeof(int) });
                    filterExpression = Expression.Call(propertyAccess, equalsMethod!, filterValue);
                }
                else continue;
                var expression = Expression.Lambda<Func<TEntity, bool>>(filterExpression, parameter);
                predicate = predicate.And(expression);
            }
        }

        return predicate.Body.NodeType == ExpressionType.Constant ? null : predicate;
    }
}
