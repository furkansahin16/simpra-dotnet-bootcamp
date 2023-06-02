using MediatR;

namespace SimpraApi.Service.Controllers;

[Authorize(Roles = Roles.Manager)]
public class CategoryController : BaseApiController
{
    public CategoryController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    [Authorize(Roles = Roles.Standart)]
    public async Task<IResponse> GetAll() => await Mediator.Send(new GetAllCategoryQueryRequest());

    [HttpGet("{Id}")]
    [Authorize(Roles = Roles.Standart)]
    public async Task<IResponse> GetById([FromRoute] GetByIdCategoryQueryRequest request) => await Mediator.Send(request);

    [HttpGet("search")]
    [Authorize(Roles = Roles.Standart)]
    public async Task<IResponse> GetWhere([FromQuery] GetWhereCategoryQueryRequest request) => await Mediator.Send(request);

    [HttpPost]
    public async Task<IResponse> Create(CreateCategoryCommandRequest request) => await Mediator.Send(request);

    [HttpPut]
    public async Task<IResponse> Update(UpdateCategoryCommandRequest request) => await Mediator.Send(request);

    [HttpDelete("{Id}")]
    public async Task<IResponse> Update([FromRoute] DeleteCategoryCommandRequest request) => await Mediator.Send(request);
}
