using DataAccessLayer.Dtos.CourseDtos;
using DataAccessLayer.Entities;

namespace ApplicationLayer.Services
{
    public interface ICourseService
    {
        Task AddAsync(CourseDto courseDto);
        Task DeleteAsync(Guid id);
        Task<List<CourseDtoWithId>> ReadAllAsync();
        Task<CourseDtoWithId> ReadAsync(Guid id);
        Task UpdateAsync(CourseDtoWithId courseDto);
        Task AddCourseAssignmentAsync(Course course, Assignment assignment);
    }
}