using ApplicationLayer.Services;
using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Mappers;
using DataAccessLayer.Repositories.CourseRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //ToList convertion will happen eventually in the servives
            return Ok(await _courseRepository.ReadAll().ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var item = await _courseRepository.ReadAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _courseRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Course course)
        {
            //TODO - add mapping and change to DTOs
            await _courseRepository.AddAsync(course);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, Course course)
        {
            course.Id = id;

            //It will throw InternalServerError automatically upon exception
            await _courseRepository.UpdateAsync(course);
            return NoContent();
        }
        [HttpPut("{courseId}")]
        public async Task<IActionResult> AddCourseAssignment(Guid courseId, Assignment assignment)
        {
            Course course = _mapper.Map<Course>(await _courseService.ReadAsync(courseId));
            await _courseService.AddCourseAssignmentAsync(course, assignment);
            return NoContent();
        }
    }
}
