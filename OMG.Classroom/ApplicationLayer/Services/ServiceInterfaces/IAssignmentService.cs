using DataAccessLayer.Dtos.AssignmentDtos;

namespace ApplicationLayer.Services
{
    public interface IAssignmentService
    {
        Task AddAsync(AssignmentDto assignmentDto);
        Task DeleteAsync(Guid id);
        Task<List<AssignmentDto>> ReadAll();
        Task<AssignmentDtoWithId> ReadAsync(Guid id);
        Task UpdateAsync(AssignmentDtoWithId assignmentDtoWithCollectionsWithId);
    }
}