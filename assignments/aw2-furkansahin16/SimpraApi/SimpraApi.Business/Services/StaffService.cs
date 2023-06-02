using System.Linq.Expressions;
using System.Net;

namespace SimpraApi.Business.Services;
public class StaffService : IStaffService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Staff> _repository;
    private readonly IMapper _mapper;
    private readonly string ModelName = typeof(Staff).Name;
    public StaffService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._repository = _unitOfWork.GetRepository<Staff>();
        _mapper = mapper;
    }
    public async Task<IResponse> CreateStaffAsync(StaffCreateRequest request)
    {
        var model = _mapper.Map<Staff>(request);
        await _repository.AddAsync(model);

        return (await _unitOfWork.SaveChangesAsync()) ??
            new SuccessDataResponse<StaffResponse>(_mapper.Map<StaffResponse>(model), String.Format(Messages.AddSuccess, ModelName), HttpStatusCode.Created);
    }
    public async Task<IResponse> CreateStaffAsync(params StaffCreateRequest[] request)
    {
        var models = _mapper.Map<List<Staff>>(request);
        await _repository.AddRangeAsync(models);

        return (await _unitOfWork.SaveChangesAsyncWithTransaction()) ??
            new SuccessDataResponse<IEnumerable<StaffResponse>>(_mapper.Map<List<StaffResponse>>(models), String.Format(Messages.AddRangeSuccess, ModelName), HttpStatusCode.Created);
    }
    public async Task<IResponse> UpdateStaffAsync(StaffUpdateRequest request)
    {
        var model = await _repository.GetAsync(x => x.Id == request.Id);
        var updatedModel = _mapper.Map(request, model);
        await _repository.UpdateAsync(updatedModel!);

        return (await _unitOfWork.SaveChangesAsync()) ??
            new SuccessDataResponse<StaffResponse>(_mapper.Map<StaffResponse>(model), String.Format(Messages.UpdateSuccess, ModelName), HttpStatusCode.Accepted);
    }

    public async Task<IResponse> DeleteStaffByIdAsync(int id)
    {
        var model = await _repository.GetAsync(x => x.Id == id);
        await _repository.DeleteAsync(model!);

        return (await _unitOfWork.SaveChangesAsync()) ??
            new SuccessResponse(String.Format(Messages.DeleteSuccess, ModelName), HttpStatusCode.OK);
    }

    public async Task<IResponse> GetAllAsync()
    {
        if (!await _repository.AnyAsync()) return new ErrorResponse(String.Format(Messages.ListError, ModelName), HttpStatusCode.NoContent);

        var models = await _repository.GetAllAsync(false);

        return new SuccessDataResponse<IEnumerable<StaffResponse>>(_mapper.Map<List<StaffResponse>>(models), String.Format(Messages.ListSuccess, ModelName), HttpStatusCode.OK);
    }

    public async Task<IResponse> GetByIdAsync(int id)
    {
        var model = await _repository.GetAsync(x => x.Id == id, false);

        return new SuccessDataResponse<StaffResponse>(_mapper.Map<StaffResponse>(model), String.Format(Messages.GetSuccess, ModelName), HttpStatusCode.OK);
    }

    public async Task<IResponse> GetAllByFilter(StaffFilter filter)
    {
        var expressions = new List<Expression<Func<Staff, bool>>>();

        expressions.Add(x => x.LastName.ToLower().Contains(filter.LastName ?? ""));
        expressions.Add(x => x.Country.ToLower().Contains(filter.Country ?? ""));

        var finalExpression = expressions.Aggregate((Expression<Func<Staff, bool>>)null, (current, expression) =>
        {
            if (current == null) return expression;
            var invoked = Expression.Invoke(expression, current.Parameters);
            return Expression.Lambda<Func<Staff, bool>>(Expression.AndAlso(current.Body, invoked), current.Parameters);
        });

        var models = await _repository.GetAllAsync(finalExpression, false);
        return models.Any()
            ? new SuccessDataResponse<IEnumerable<StaffResponse>>(_mapper.Map<List<StaffResponse>>(models), String.Format(Messages.ListSuccess, ModelName), HttpStatusCode.OK)
            : new ErrorResponse(String.Format(Messages.ListError, ModelName), HttpStatusCode.NoContent);
    }
}
