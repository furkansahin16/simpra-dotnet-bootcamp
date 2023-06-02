namespace SimpraApi.Application;
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Name).ValidateEmpty().ValidateLength(30);
        RuleFor(x => x.Url).ValidateEmpty().ValidateLength(30)
            .Must(root => root.IsValidUrl()).WithMessage(Messages.Validation.Format.Format("url"));
        RuleFor(x => x.Tag).ValidateEmpty().ValidateLength(100);
        Unless(x => string.IsNullOrEmpty(x.CategoryId), () =>
        {
            RuleFor(x => x.CategoryId!).ValidateId();
        });
        RuleFor(x => x.Id).ValidateId();
    }
}