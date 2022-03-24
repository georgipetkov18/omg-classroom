using DataAccessLayer.Dtos.CourseDtos;

namespace ApplicationLayer.Services
{
    public interface ICourseService
    {
        Task AddAsync(CourseDto courseDto);
        Task DeleteAsync(Guid id);
        Task<List<CourseDtoWithId>> ReadAllAsync();
        Task<CourseDtoWithId> ReadAsync(Guid id);
        Task UpdateAsync(CourseDtoWithId courseDto);
    }
}