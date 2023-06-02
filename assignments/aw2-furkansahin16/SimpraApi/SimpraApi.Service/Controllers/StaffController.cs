namespace SimpraApi.Service.Controllers;

[ServiceFilter(typeof(CacheResourceFilter))]
public class StaffController : BaseApiController
{
    private readonly IStaffService _staffService;

    public StaffController(IStaffService staffService)
    {
        _staffService = staffService;
    }

    [HttpGet("{id}")]
    [ServiceFilter(typeof(NotFoundFilter))]
    public async Task<IResponse> GetStaff(int id)
    {
        return await _staffService.GetByIdAsync(id);
    }

    [HttpGet]
    public async Task<IResponse> GetAll()
    {
        return await _staffService.GetAllAsync();
    }

    [CustomValidate(typeof(StaffCreateRequestValidator))]
    [ServiceFilter(typeof(EmailFilter))]
    [HttpPost]
    public async Task<IResponse> Add(StaffCreateRequest request)
    {
        return await _staffService.CreateStaffAsync(request);
    }

    [ServiceFilter(typeof(NotFoundFilter))]
    [CustomValidate(typeof(StaffUpdateRequestValidator))]
    [ServiceFilter(typeof(EmailFilter))]
    [HttpPut]
    public async Task<IResponse> Update(StaffUpdateRequest request)
    {
        return await _staffService.UpdateStaffAsync(request);
    }

    [ServiceFilter(typeof(NotFoundFilter))]
    [HttpDelete("{id}")]
    public async Task<IResponse> Delete(int id)
    {
        return await _staffService.DeleteStaffByIdAsync(id);
    }

    [HttpGet("[action]")]
    public async Task<IResponse> Filter([FromQuery] StaffFilter filter)
    {
        return await _staffService.GetAllByFilter(filter);
    }
}
