namespace SimpraApi.Application;

public class GetAllCategoryQueryHandler : GetAllQueryHandler<Category, GetAllCategoryQueryRequest, CategoryDto>
{
    public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
