using DataAccessLayer.Dtos.AssignmentDtos;

namespace ApplicationLayer.Services
{
    public interface IAssignmentService
    {
        Task AddAsync(AssignmentDto assignmentDto);
        Task DeleteAsync(Guid id);
        Task<List<AssignmentDtoWithId>> ReadAllAsync();
        Task<AssignmentDtoWithId> ReadAsync(Guid id);
        Task UpdateAsync(AssignmentDtoWithId assignmentDto);
    }
}