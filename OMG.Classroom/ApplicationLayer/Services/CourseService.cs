using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Dtos.CourseDtos;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.CourseRepositories;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task AddAsync(CourseDto courseDto)
        {
            await _courseRepository.AddAsync(courseDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _courseRepository.DeleteAsync(id);
        }

        public async Task<List<CourseDto>> ReadAllAssync()
        {
            return await _courseRepository.ReadAll().ToListAsync();
        }

        public async Task<CourseDtoWithId> ReadAsync(Guid id)
        {
            return await _courseRepository.ReadAsync(id);
        }

        public async Task UpdateAsync(CourseDtoWithId courseDto)
        {
            await _courseRepository.UpdateAsync(courseDto);
        }
    }
}
