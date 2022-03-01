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
        private readonly StudentRepository _studentRepository;
        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Student>> AllStudents()
        {
            return await _studentRepository.ReadAll().ToListAsync();
        }
        [HttpGet]
        public async Task<Student> GetStudent(string id)
        {
            Guid guid = Guid.Parse(id);
            return await _studentRepository.ReadAsync(guid);
        }
        [HttpPost]
        public async Task Delete(string id)
        {
            Guid guid = Guid.Parse(id);
            await _studentRepository.DeleteAsync(guid);
        }
        [HttpPost]
        public async Task Create(string name, string email, string password, int age)
        {
            Student student = new Student()
            {
                Id = Guid.NewGuid(),
                Age = age,
                Name = name,
                Email = email,
                Password = password
            };
            await _studentRepository.AddAsync(student);
        }
        [HttpPost]
        public async Task Update(string id, string name, string email, string password, int age)
        {
            Student student = new Student()
            {
                Id = Guid.Parse(id),
                Age = age,
                Name = name,
                Email = email,
                Password = password
            };
            await _studentRepository.UpdateAsync(student);
        }
    }
}
