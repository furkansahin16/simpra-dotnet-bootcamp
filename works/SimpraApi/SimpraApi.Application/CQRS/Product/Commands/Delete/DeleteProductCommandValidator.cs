namespace SimpraApi.Application;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
{
	public DeleteProductCommandValidator()
	{
		RuleFor(x => x.Id).ValidateId();
	}
}
