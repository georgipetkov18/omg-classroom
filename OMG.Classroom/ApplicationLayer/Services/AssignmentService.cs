using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Services.ServiceInterfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.AssignmentRepositories;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services//sth
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }
        public async Task CreateAsync(Assignment assignment)
        {
            await _assignmentRepository.AddAsync(assignment);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _assignmentRepository.DeleteAsync(id);
        }

        public async Task<List<Assignment>> GetAllAsync()
        {
            return await _assignmentRepository.ReadAll().ToListAsync();
        }

        public async Task<Assignment> GetAsync(Guid id)
        {
            return await _assignmentRepository.ReadAsync(id);
        }

        public async Task UpdateAsync(Assignment assignment)
        {
            await _assignmentRepository.UpdateAsync(assignment);
        }
    }
}
