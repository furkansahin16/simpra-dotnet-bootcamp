namespace SimpraApi.Application;
public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).ValidateEmpty().ValidateLength(30);
    }
}