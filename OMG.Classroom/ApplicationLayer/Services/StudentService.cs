using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Dtos.StudentDtos;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.StudentRepositories;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task AddAsync(StudentDto studentDto)
        {
            await _studentRepository.AddAsync(studentDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _studentRepository.DeleteAsync(id);
        }

        public async Task<List<StudentDtoWithId>> ReadAllAsync()
        {
            return await _studentRepository.ReadAll().ToListAsync();
        }

        public async Task<StudentDtoWithId> ReadAsync(Guid id)
        {
            return await _studentRepository.ReadAsync(id);
        }

        public async Task UpdateAsync(StudentDtoWithId studentDto)
        {
            await _studentRepository.UpdateAsync(studentDto);
        }
    }
}
