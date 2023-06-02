namespace SimpraApi.Application;

public class GetByIdProductQueryValidator : AbstractValidator<GetByIdProductQueryRequest>
{
	public GetByIdProductQueryValidator()
	{
		RuleFor(x => x.Id).ValidateId();
	}
}
