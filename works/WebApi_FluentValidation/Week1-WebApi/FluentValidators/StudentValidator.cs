using FluentValidation;
using System.Text.RegularExpressions;

namespace Week1_WebApi.FluentValidators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .Length(5, 100).WithMessage("Name property must be 5-100 character length");

            RuleFor(x => x.Email)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("Invalid email format")
                .Length(10, 100).WithMessage("Invalid email length");

            RuleFor(x => x.Phone)
                .Length(10,10).WithMessage("Phone number must not be less or more than 10 characters.")
                .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("Invalid phone format");
        }
    }
}
