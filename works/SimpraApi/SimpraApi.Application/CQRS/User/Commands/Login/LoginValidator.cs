namespace SimpraApi.Application;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).ValidateEmail();
        RuleFor(x => x.Password).ValidateEmpty();
    }
}
