using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Dtos.TeacherDtos;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.TeacherRepositories;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task AddAsync(TeacherDto teacherDto)
        {
            await _teacherRepository.AddAsync(teacherDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _teacherRepository.DeleteAsync(id);
        }

        public async Task<List<TeacherDtoWithId>> ReadAllAsync()
        {
            return await _teacherRepository.ReadAll().ToListAsync();
        }

        public async Task<TeacherDtoWithId> ReadAsync(Guid id)
        {
            return await _teacherRepository.ReadAsync(id);
        }

        public async Task UpdateAsync(TeacherDtoWithId teacherDto)
        {
            await _teacherRepository.UpdateAsync(teacherDto);
        }
    }
}
