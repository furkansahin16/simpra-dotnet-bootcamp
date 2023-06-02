using MediatR;

namespace SimpraApi.Service.Controllers;

[Route("api/v1/[controller]")]
[Authorize(Policy = Policies.AllUser)]
public abstract class BaseApiController : ControllerBase
{
    protected readonly IMediator Mediator;
    public BaseApiController(IMediator mediator) => Mediator = mediator;
}
