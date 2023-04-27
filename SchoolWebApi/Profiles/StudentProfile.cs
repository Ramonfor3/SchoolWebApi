using AutoMapper;
using SchoolWebApi.Dtos.StudentsDto;
using SchoolWebApi.Models;

namespace SchoolWebApi
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
