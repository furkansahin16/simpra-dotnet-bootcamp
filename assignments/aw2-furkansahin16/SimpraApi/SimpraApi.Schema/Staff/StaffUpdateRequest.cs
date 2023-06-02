using SimpraApi.Base;

namespace SimpraApi.Schema;

public class StaffUpdateRequest : StaffRequest,IBaseUpdateRequest
{
    public int Id { get; set; }
}
