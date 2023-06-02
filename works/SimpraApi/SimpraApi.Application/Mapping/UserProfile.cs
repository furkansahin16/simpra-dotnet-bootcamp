namespace SimpraApi.Application;
public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<CreateUserCommandRequest, User>()
			.ForMember(x => x.Email, cfg => cfg.MapFrom(src => src.Email.ToLower()))
			.ForMember(x => x.FirstName, cfg => cfg.MapFrom(src => src.FirstName.NormalizeString()))
			.ForMember(x => x.LastName, cfg => cfg.MapFrom(src => src.LastName.NormalizeString()))
			.ForMember(x => x.Password, cfg => cfg.MapFrom(src => src.Password.CreatePasswordHash()));
		CreateMap<ChangeUserRoleCommandRequest, User>()
			.ForMember(x => x.Role, cfg => cfg.MapFrom(src => src.Role.ToLower()));
		
		CreateMap<User,UserDto>();
		CreateMap<User,UserDetailDto>();
	}
}
