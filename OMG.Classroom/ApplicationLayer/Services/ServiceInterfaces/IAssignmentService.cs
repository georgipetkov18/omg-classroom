using DataAccessLayer.Entities;

namespace ApplicationLayer.Services.ServiceInterfaces
{
    public interface IAssignmentService
    {
        Task CreateAsync(Assignment assignment);
        Task DeleteAsync(Guid id);
        Task<List<Assignment>> GetAllAsync();
        Task<Assignment> GetAsync(Guid id);
        Task UpdateAsync(Assignment assignment);
    }
}