using API.Helpers;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.RoleRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            //ToList convertion will happen eventually in the servives
            return Ok(await _roleRepository.ReadAll().ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var item = await _roleRepository.ReadAsync(id);
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
                await _roleRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Role role)
        {
            //TODO - add mapping and change to DTOs
            await _roleRepository.AddAsync(role);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, Role role)
        {
            role.Id = id;

            //It will throw InternalServerError automatically upon exception
            await _roleRepository.UpdateAsync(role);
            return NoContent();
        }
    }
}
