namespace SimpraApi.Application;
public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommandRequest>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id).ValidateId();
    }
}