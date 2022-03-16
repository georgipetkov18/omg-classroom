using DataAccessLayer.Dtos.AssignmentDtos;

namespace ApplicationLayer.Services
{
    public interface IAssignmentService
    {
        Task AddAsync(AssignmentDtoWithCollections assignmentDto);
        Task DeleteAsync(Guid id);
        Task<List<AssignmentDtoWithId>> ReadAll();
        Task<AssignmentDtoWithId> ReadAsync(Guid id);
        Task UpdateAsync(AssignmentDtoWithCollectionsWithId assignmentDtoWithCollectionsWithId);
    }
}