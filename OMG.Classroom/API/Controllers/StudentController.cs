using ApplicationLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Dtos.StudentDtos;
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
        //To be changed to service in the future and to DTOs/Models in the Future
        private readonly IStudentService service;
        public StudentController(IStudentService service)
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
        public async Task<IActionResult> CreateAsync(StudentDto studentDto)
        {
            //TODO - add mapping and change to DTOs
            await service.AddAsync(studentDto);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, StudentDtoWithId studentDto)
        {
            studentDto.Id = id;
            
            //It will throw InternalServerError automatically upon exception
            await service.UpdateAsync(studentDto);
            return NoContent();
        }
    }
}
