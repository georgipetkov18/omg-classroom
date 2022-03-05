using AutoMapper;
using DataAccessLayer.Dtos.AssignmentDtos;
using DataAccessLayer.Dtos.CourseDtos;
using DataAccessLayer.Dtos.MessageDtos;
using DataAccessLayer.Dtos.StudentDtos;
using DataAccessLayer.Dtos.TeacherDtos;
using DataAccessLayer.Dtos.UserDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AssignmentDto, Assignment>().ReverseMap();
            CreateMap<AssignmentDtoWithId, Assignment>().ReverseMap();
            CreateMap<AssignmentDtoWithMessages, Assignment>().ReverseMap();
            CreateMap<AssignmentDtoWithMessagesWithId, Assignment>().ReverseMap();

            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<CourseDtoWithId, Course>().ReverseMap();
            CreateMap<CourseDtoWithStudentsAndAssignments, Course>().ReverseMap();
            CreateMap<CourseDtoWithStudentsAndAssignmentsWithId, Course>().ReverseMap();

            CreateMap<MessageDto, Message>().ReverseMap();
            CreateMap<MessageDtoWithId, Message>().ReverseMap();

            CreateMap<StudentDto, Student>().ReverseMap();
            CreateMap<StudentDtoWithId, Student>().ReverseMap();
            CreateMap<StudentDtoWithAssignments, Student>().ReverseMap();
            CreateMap<StudentDtoWIthAssignmentsWithId, Student>().ReverseMap();

            CreateMap<TeacherDto, Teacher>().ReverseMap();
            CreateMap<TeacherDtoWithId, Teacher>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserDtoWithId, User>().ReverseMap();
            CreateMap<UserDtoWithCoursesAndMessages, User>().ReverseMap();
            CreateMap<UserDtoWithCoursesAndMessagesWithId, User>().ReverseMap();
        }
    }
}
