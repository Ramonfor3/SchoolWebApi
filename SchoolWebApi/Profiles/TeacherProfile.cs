using AutoMapper;
using SchoolWebApi.Dtos.TeachersDto;
using SchoolWebApi.Models;

namespace SchoolWebApi
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDto>();
            CreateMap<CreateTeacherDto, Teacher>();
            CreateMap<UpdateTeacherDto, Teacher>();
        }
    }
}

