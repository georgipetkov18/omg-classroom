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

        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentController(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //ToList convertion will happen eventually in the servives
            return Ok(await _assignmentRepository.ReadAll().ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var item = await _assignmentRepository.ReadAsync(id);
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
                await _assignmentRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Assignment assignment)
        {
            //TODO - add mapping and change to DTOs
            await _assignmentRepository.AddAsync(assignment);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, Assignment assignment)
        {
            assignment.Id = id;

            //It will throw InternalServerError automatically upon exception
            await _assignmentRepository.UpdateAsync(assignment);
            return NoContent();
        }
    }
}
