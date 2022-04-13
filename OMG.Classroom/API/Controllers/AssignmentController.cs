using ApplicationLayer.Services;
using DataAccessLayer.Dtos.AssignmentDtos;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.AssignmentRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService service;
        public AssignmentController(IAssignmentService service)
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
        public async Task<IActionResult> CreateAsync(AssignmentDto assignmentDto)
        {
            //TODO - add mapping and change to DTOs
            await service.AddAsync(assignmentDto);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, AssignmentDtoWithId assignmentDto)
        {
            assignmentDto.Id = id;

            //It will throw InternalServerError automatically upon exception
            await service.UpdateAsync(assignmentDto);
            return NoContent();
        }
    }
}
