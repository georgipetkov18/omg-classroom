using API.Helpers;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.CourseRepositories;
using DataAccessLayer.Repositories.StudentRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        //To be changed to service in the future and to DTOs/Models in the Future
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        public StudentController(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //ToList convertion will happen eventually in the servives
            return Ok(await _studentRepository.ReadAll().ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var item = await _studentRepository.ReadAsync(id);
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
                await _studentRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }          
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Student student)
        {
            //TODO - add mapping and change to DTOs
            await _studentRepository.AddAsync(student);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, Student student)
        {
            student.Id = id;
            
            //It will throw InternalServerError automatically upon exception
            await _studentRepository.UpdateAsync(student);
            return NoContent();
        }
        [Route("/attach")]
        [HttpPost("{courseId}")]
        public async Task<IActionResult> AttachStudentToCourse(Guid courseId, Student student)
        {
            //Logic to be move to service
            var studentFromDB = await _studentRepository.ReadAsync(student.Id);
            if (studentFromDB is null)
            {
                return NotFound();
            }
            var courseFromDB = await _courseRepository.ReadAsync(courseId);
            if(courseFromDB is null)
            {
                return NotFound();
            }
            
            studentFromDB.Courses.Add(courseFromDB);
            await _studentRepository.UpdateAsync(student);
            return NoContent();

        }
    }
}
