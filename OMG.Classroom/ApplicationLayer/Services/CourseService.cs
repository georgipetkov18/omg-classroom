using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Dtos.CourseDtos;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.AssignmentRepositories;
using DataAccessLayer.Repositories.CourseRepositories;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository,IAssignmentRepository assignmentRepository,IMapper mapper)
        {
            _courseRepository = courseRepository;
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(CourseDto courseDto)
        {
            await _courseRepository.AddAsync(_mapper.Map<Course>(courseDto));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _courseRepository.DeleteAsync(id);
        }

        public async Task<List<CourseDtoWithId>> ReadAllAsync()
        {
            return _mapper.Map<List<Course>, List< CourseDtoWithId >> (await _courseRepository.ReadAll().ToListAsync()); 
        }

        public async Task<CourseDtoWithId> ReadAsync(Guid id)
        {
            return _mapper.Map<CourseDtoWithId>(await _courseRepository.ReadAsync(id));
        }

        public async Task UpdateAsync(CourseDtoWithId courseDto)
        {
            await _courseRepository.UpdateAsync(_mapper.Map<Course>(courseDto));
        }
        public async Task AddCourseAssignmentAsync(Course course,Assignment assignment)
        {
            assignment.Course = course;
            course.Assignments.Add(assignment);
            await _courseRepository.UpdateAsync(course);
            await _assignmentRepository.UpdateAsync(assignment);
        }
    }
}
