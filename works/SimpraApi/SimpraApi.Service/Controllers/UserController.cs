using MediatR;

namespace SimpraApi.Service.Controllers;

public class UserController : BaseApiController
{

    public UserController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IResponse> GetUsers([FromQuery] GetWhereUserQueryRequest request) => await Mediator.Send(request);

    [HttpPut("[action]")]
    public async Task<IResponse> ChangeRole([FromBody] ChangeUserRoleCommandRequest request) => await Mediator.Send(request);

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IResponse> Signup([FromBody] CreateUserCommandRequest request) => await Mediator.Send(request);

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IResponse> Login([FromBody] LoginRequest request) => await Mediator.Send(request);
}
