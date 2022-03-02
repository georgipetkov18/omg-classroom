using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.StudentRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //To be changed to service in the future and to DTOs/Models/ViewModels in the Future
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<Student>>> GetAllAsync()
        {
            return await _studentRepository.ReadAll().ToListAsync();
        }
        [HttpGet("id")]
        public async Task<ActionResult<Student>> GetAsync(Guid id)
        {
            Student? item = await _studentRepository.ReadAsync(id);
            if (item is null)
            {
               return NotFound();
            }
            return item;
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _studentRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }          
            
        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateAsync(Student student)
        {
            //TODO - add mapping and change to ViewModel
            await _studentRepository.AddAsync(student);
            return CreatedAtAction(nameof(GetAsync), new { id = student.Id }, student);
        }
        [HttpPut("id")]
        public async Task<ActionResult<Student>> UpdateAsync(Guid id, Student student)
        {
            //TODO - add mapping and change to ViewModel
            if (student.Id != id)
            {
                return BadRequest();
            }
            try
            {
                await _studentRepository.UpdateAsync(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
