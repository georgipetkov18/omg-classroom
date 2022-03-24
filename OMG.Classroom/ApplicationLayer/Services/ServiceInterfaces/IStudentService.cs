using DataAccessLayer.Dtos.StudentDtos;

namespace ApplicationLayer.Services
{
    public interface IStudentService
    {
        Task AddAsync(StudentDto studentDto);
        Task DeleteAsync(Guid id);
        Task<List<StudentDtoWithId>> ReadAllAsync();
        Task<StudentDtoWithId> ReadAsync(Guid id);
        Task UpdateAsync(StudentDtoWithId studentDto);
    }
}