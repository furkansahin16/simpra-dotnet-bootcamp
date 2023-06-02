using SimpraApi.Base;

namespace SimpraApi.Schema;
public class StaffProfile : Profile
{
    public StaffProfile()
    {
        CreateMap<StaffCreateRequest, Staff>()
            .ForMember(x => x.FirstName, cfg => cfg.MapFrom(src => src.FirstName.NormalizeString()))
            .ForMember(x => x.LastName, cfg => cfg.MapFrom(src => src.LastName.NormalizeString()))
            .ForMember(x => x.Email, cfg => cfg.MapFrom(src => src.Email.ToLower()))
            .ForMember(x => x.DateOfBirth, cfg => cfg.MapFrom(src => Convert.ToDateTime(src.DateOfBirth)));
        CreateMap<StaffUpdateRequest, Staff>()
            .ForMember(x => x.FirstName, cfg => cfg.MapFrom(src => src.FirstName.NormalizeString()))
            .ForMember(x => x.LastName, cfg => cfg.MapFrom(src => src.LastName.NormalizeString()))
            .ForMember(x => x.Email, cfg => cfg.MapFrom(src => src.Email.ToLower()));
        CreateMap<Staff, StaffResponse>()
            .ForMember(x => x.DateOfBirth, cfg => cfg.MapFrom(src => src.DateOfBirth.ToString("d")))
            .ForMember(x => x.CreatedAt, cfg => cfg.MapFrom(src => src.CreatedAt.ToString("g")));
    }
}
