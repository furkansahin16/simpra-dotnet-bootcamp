using System.Reflection;
using System.Text.RegularExpressions;

namespace SimpraApi.Application;
public static class ValidationRules
{
    public static IRuleBuilderOptions<T, string> ValidateEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .ValidateEmpty()
            .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage(Messages.FormatError.Format(ruleBuilder.GetPropertyName()))
            .ValidateLength(64);
    }
    
    public static IRuleBuilderOptions<T, string> ValidatePassword<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .ValidateEmpty()
            .Matches(new Regex("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,32}$")).WithMessage(Messages.PasswordFormat);
    }
    
    public static IRuleBuilderOptions<T, string> ValidateEmpty<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(Messages.EmptyError.Format(ruleBuilder.GetPropertyName()));
    }
    
    public static IRuleBuilderOptions<T, string> ValidateLength<T>(this IRuleBuilder<T, string> ruleBuilder,int maxLength)
    {
        return ruleBuilder
            .MaximumLength(maxLength).WithMessage(Messages.LengthError.Format(ruleBuilder.GetPropertyName(),maxLength.ToString()));
    }
    
    public static IRuleBuilderOptions<T, string> ValidateId<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .ValidateEmpty()
            .Must(id => id.IsValidGuid()).WithMessage(Messages.FormatError.Format("Id"));
    }

    private static string GetPropertyName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        var ruleProperty = ruleBuilder.GetType().GetProperty("Rule");
        var rule = ruleProperty?.GetValue(ruleBuilder);

        var propertyNameProperty = rule?.GetType().GetProperty("PropertyName");
        var propertyName = propertyNameProperty?.GetValue(rule) as string;

        return propertyName ?? "field";
    }
}
