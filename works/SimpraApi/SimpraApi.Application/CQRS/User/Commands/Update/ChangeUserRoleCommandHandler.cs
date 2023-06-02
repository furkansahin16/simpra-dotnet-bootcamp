namespace SimpraApi.Application;
public class ChangeUserRoleCommandHandler : UpdateCommandHandler<User, ChangeUserRoleCommandRequest, UserDetailDto>
{
    public ChangeUserRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    public override async Task<IResponse> Handle(ChangeUserRoleCommandRequest request, CancellationToken cancellationToken)
    {
        IResponse response = await base.Handle(request, cancellationToken);
        if (response.IsSuccess) Log.Information(Messages.Log.UserRoleChanged, Entity, request.Role);
        return response;
    }
}
