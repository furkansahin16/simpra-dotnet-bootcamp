namespace SimpraApi.Application;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName).ValidateEmpty().ValidateLength(30);
        RuleFor(x => x.LastName).ValidateEmpty().ValidateLength(30);
        RuleFor(x => x.Email).ValidateEmail();
        RuleFor(x => x.Password).ValidatePassword();
        RuleFor(x => new { x.Password, x.PasswordRetry })
            .Must(x => x.Password == x.PasswordRetry).WithMessage("Passwords do not match");
    }
}