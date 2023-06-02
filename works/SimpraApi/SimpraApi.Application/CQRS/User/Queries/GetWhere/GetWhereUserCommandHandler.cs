namespace SimpraApi.Application;
public class GetWhereUserQueryHandler : GetWhereQueryHandler<User, GetWhereUserQueryRequest, UserDetailDto>
{
    public GetWhereUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}
