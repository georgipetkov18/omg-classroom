using ApplicationLayer.Services;
using DataAccessLayer.Dtos.CourseDtos;
using DataAccessLayer.Entities;
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
        private readonly ICourseService service;
        public CourseController(ICourseService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //ToList convertion will happen eventually in the servives
            return Ok(await service.ReadAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var item = await service.ReadAsync(id);
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
                await service.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CourseDto course)
        {
            //TODO - add mapping and change to DTOs
            await service.AddAsync(course);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, CourseDtoWithId courseDto)
        {
            courseDto.Id = id;

            //It will throw InternalServerError automatically upon exception
            await service.UpdateAsync(courseDto);
            return NoContent();
        }
    }
}
