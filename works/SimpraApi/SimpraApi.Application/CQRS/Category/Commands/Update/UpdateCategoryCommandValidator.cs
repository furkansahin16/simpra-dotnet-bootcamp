namespace SimpraApi.Application;
public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommandRequest>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).ValidateEmpty().ValidateLength(30);
    }
}