using AutoMapper;
using DataAccessLayer.Dtos.AssignmentDtos;
using DataAccessLayer.Dtos.CourseDtos;
using DataAccessLayer.Dtos.MessageDtos;
using DataAccessLayer.Dtos.StudentDtos;
using DataAccessLayer.Dtos.TeacherDtos;
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
            CreateMap<AssignmentDtoWithCollections, Assignment>().ReverseMap();
            CreateMap<AssignmentDtoWithCollectionsWithId, Assignment>().ReverseMap();

            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<CourseDtoWithId, Course>().ReverseMap();
            CreateMap<CourseDtoWithCollections, Course>().ReverseMap();
            CreateMap<CourseDtoWithCollectionsWithId, Course>().ReverseMap();

            CreateMap<MessageDto, Message>().ReverseMap();
            CreateMap<MessageDtoWithId, Message>().ReverseMap();

            CreateMap<StudentDto, Student>().ReverseMap();
            CreateMap<StudentDtoWithId, Student>().ReverseMap();
            CreateMap<StudentDtoWithCollections, Student>().ReverseMap();
            CreateMap<StudentDtoWithCollectionsWithId, Student>().ReverseMap();

            CreateMap<TeacherDto, Teacher>().ReverseMap();
            CreateMap<TeacherDtoWithId, Teacher>().ReverseMap();
        }
    }
}
