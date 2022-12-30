using AutoMapper;
using Dtos;
using SchoolWebApi.Dtos;
using SchoolWebApi.Models;

namespace DataAccess
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
        }
    }
}
