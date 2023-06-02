namespace SimpraApi.Application;
public class GetByIdCategoryQueryValidator : AbstractValidator<GetByIdCategoryQueryRequest>
{
    public GetByIdCategoryQueryValidator()
    {
        RuleFor(x => x.Id).ValidateId();
    }
}