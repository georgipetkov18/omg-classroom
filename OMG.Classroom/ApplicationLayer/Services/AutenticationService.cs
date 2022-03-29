using AutoMapper;
using DataAccessLayer.Dtos.AuthenticationDTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Mappers;
using DataAccessLayer.Repositories.StudentRepositories;
using DataAccessLayer.Repositories.TeacherRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class AutenticationService : IAutenticationService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public AutenticationService(IStudentRepository studentRepository, ITeacherRepository teacherRepository, IMapper mapperProfile)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _mapper = mapperProfile;
        }

        public async Task<UserDTO> FindUser(Guid id)
        {
            User user = await _studentRepository.ReadAsync(id);
            if (user is null)
            {
                user = await _teacherRepository.ReadAsync(id);
            }
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO SearchUsers(AuthenticationRequest request)
        {
            User user = _studentRepository.ReadAll().SingleOrDefault(x =>
            x.Name == request.Username && x.Password == request.Password);

            if (user == null)
            {
                user = _teacherRepository.ReadAll().SingleOrDefault(x =>
                x.Name == request.Username && x.Password == request.Password);
            }
            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }
    }
}
