using MediatR;

namespace SimpraApi.Service.Controllers;

[Route("api/v1/[controller]")]
[Authorize(Roles = Roles.Admin)]
public abstract class BaseApiController : ControllerBase
{
    protected readonly IMediator Mediator;
    public BaseApiController(IMediator mediator) => Mediator = mediator;
}
