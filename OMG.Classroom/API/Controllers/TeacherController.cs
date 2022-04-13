using ApplicationLayer.Services;
using DataAccessLayer.Dtos.TeacherDtos;
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
        private readonly ITeacherService service;
        public TeacherController(ITeacherService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await service.ReadAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var teacher = await service.ReadAsync(id);
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
                await service.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(TeacherDto teacherDto)
        {
            //TODO - add mapping and change to DTOs
            await service.AddAsync(teacherDto);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, TeacherDtoWithId teacherDto)
        {
            teacherDto.Id = id;

            //It will throw InternalServerError automatically upon exception
            await service.UpdateAsync(teacherDto);
            return NoContent();
        }
    }
}
