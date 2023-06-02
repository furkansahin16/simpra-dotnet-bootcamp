namespace SimpraApi.Business;
public interface IStaffService
{
    /// <summary>
    /// Creates a new staff member asynchronusly.
    /// </summary>
    /// <param name="request">The staff creation request containing the necessary information.</param>
    /// <returns>A task representing the asynchronous operation, returning an <see cref="IResponse"/> with the created staff member details.</returns>
    Task<IResponse> CreateStaffAsync(StaffCreateRequest request);

    /// <summary>
    /// Creates multiple staff members asynchronusly.
    /// </summary>
    /// <param name="request">An array of staff creation request containing the necessary information for each staff member.</param>
    /// <returns>A task representing the asynchronous operation, returning an <see cref="IResponse"/> with the created staff members' details.</returns>
    Task<IResponse> CreateStaffAsync(params StaffCreateRequest[] request);

    /// <summary>
    /// Updates an existing staff member asynchronously.
    /// </summary>
    /// <param name="request">The staff update request containing the updated information for the staff member.</param>
    /// <returns>A task representing the asynchronous operation, returning an <see cref="IResponse"/> with the updated staff member details.</returns>
    Task<IResponse> UpdateStaffAsync(StaffUpdateRequest request);

    /// <summary>
    /// Deletes a staff member by their ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the staff member to delete.</param>
    /// <returns>A task representing the asynchronous operation, returning an <see cref="IResponse"/> indicating the success of the deletion.</returns>
    Task<IResponse> DeleteStaffByIdAsync(int id);

    /// <summary>
    /// Retrieves all staff members asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, returning an <see cref="IResponse"/> with the list of staff members' details.</returns>
    Task<IResponse> GetAllAsync();

    /// <summary>
    /// Retrieves staff members based on a filter asynchronously.
    /// </summary>
    /// <param name="filter">The <see cref="IResponse"/> to apply  when retrieving staff members.</param>
    /// <returns>A task representing the asynchronous operation, returning an <see cref="IResponse"/> with the list of filtered staff members' details.</returns>
    Task<IResponse> GetAllByFilter(StaffFilter filter);

    /// <summary>
    /// Retrieves a staff member by their ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the staff member to retrieve.</param>
    /// <returnsA task representing the asynchronous operation, returning an <see cref="IResponse"/> with the staff member's details.></returns>
    Task<IResponse> GetByIdAsync(int id);
}
