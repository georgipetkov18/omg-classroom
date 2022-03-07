using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.TeacherRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _teacherRepository.ReadAll().ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var teacher = await _teacherRepository.ReadAsync(id);
            if(teacher==null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _teacherRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Teacher teacher)
        {
            //TODO - add mapping and change to DTOs
            await _teacherRepository.AddAsync(teacher);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, Teacher teacher)
        {
            teacher.Id = id;

            //It will throw InternalServerError automatically upon exception
            await _teacherRepository.UpdateAsync(teacher);
            return NoContent();
        }
    }
}
