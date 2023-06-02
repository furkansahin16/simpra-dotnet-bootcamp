namespace SimpraApi.Application;
public class CreateUserCommandHandler : CreateCommandHandler<User, CreateUserCommandRequest, UserDto>
{
    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    public override async Task<IResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        if (await EmailExist(request.Email))
            return new ErrorResponse(Messages.User.InvalidEmail.Format(request.Email), HttpStatusCode.Forbidden);
        return await base.Handle(request, cancellationToken);
    }
    private async Task<bool> EmailExist(string email)
    {
        return await Repository.AnyAsync(x => x.Email == email.ToLower(), true);
    }
}
