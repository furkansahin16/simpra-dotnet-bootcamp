namespace SimpraApi.Application;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).ValidateEmpty().ValidateLength(30);
        RuleFor(x => x.Url).ValidateEmpty().ValidateLength(30)
            .Must(root => root.IsValidUrl()).WithMessage("Invalid url format");
        RuleFor(x => x.Tag).ValidateEmpty().ValidateLength(100);
        RuleFor(x => x.CategoryId).ValidateId();
    }
}