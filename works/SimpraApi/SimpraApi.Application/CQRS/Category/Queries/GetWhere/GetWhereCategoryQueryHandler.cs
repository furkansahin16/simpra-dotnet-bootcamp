namespace SimpraApi.Application;

public class GetWhereCategoryQueryHandler : GetWhereQueryHandler<Category, GetWhereCategoryQueryRequest, CategoryDto>
{
    public GetWhereCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
