namespace SimpraApi.Application;
public class ChangeUserRoleCommandHandler : UpdateCommandHandler<User, ChangeUserRoleCommandRequest, UserDetailDto>
{
    public ChangeUserRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
