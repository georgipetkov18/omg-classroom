using DataAccessLayer.Dtos.TeacherDtos;

namespace ApplicationLayer.Services
{
    public interface ITeacherService
    {
        Task AddAsync(TeacherDto teacherDto);
        Task DeleteAsync(Guid id);
        Task<List<TeacherDtoWithId>> ReadAllAsync();
        Task<TeacherDtoWithId> ReadAsync(Guid id);
        Task UpdateAsync(TeacherDtoWithId teacherDto);
    }
}