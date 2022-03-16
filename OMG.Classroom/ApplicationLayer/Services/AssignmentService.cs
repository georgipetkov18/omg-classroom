using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Dtos.AssignmentDtos;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.AssignmentRepositories;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }
        public async Task AddAsync(AssignmentDto assignmentDto)
        {
            await _assignmentRepository.AddAsync(assignmentDto);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _assignmentRepository.DeleteAsync(id);
        }

        public async Task<List<AssignmentDto>> ReadAllAssync()
        {
            return await _assignmentRepository.ReadAll().ToListAsync();
        }

        public async Task<AssignmentDtoWithId> ReadAsync(Guid id)
        {
            return await _assignmentRepository.ReadAsync(id);
        }

        public async Task UpdateAsync(AssignmentDtoWithId assignmentDto)
        {
            await _assignmentRepository.UpdateAsync(assignmentDto);
        }
    }
}
