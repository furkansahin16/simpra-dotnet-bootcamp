namespace SimpraApi.Application;

public class GetByIdCategoryQueryHandler : GetByIdQueryHandler<Category, GetByIdCategoryQueryRequest, CategoryDto>
{
    public GetByIdCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
