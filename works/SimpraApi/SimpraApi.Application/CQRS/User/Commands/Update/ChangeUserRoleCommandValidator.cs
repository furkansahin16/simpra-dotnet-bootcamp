namespace SimpraApi.Application;

public class ChangeUserRoleCommandValidator : AbstractValidator<ChangeUserRoleCommandRequest>
{
	public ChangeUserRoleCommandValidator()
	{
		RuleFor(x => x.Id).ValidateId();
		RuleFor(x => x.Role)
			.ValidateEmpty()
			.Must(role =>
			string.Equals(role, Roles.Admin, StringComparison.OrdinalIgnoreCase) ||
			string.Equals(role, Roles.Manager, StringComparison.OrdinalIgnoreCase) ||
			string.Equals(role, Roles.Standard, StringComparison.OrdinalIgnoreCase)
			).WithMessage(Messages.Validation.InvalidRole);
	}
}
