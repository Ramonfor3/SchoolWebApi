using AutoMapper;
using SchoolWebApi.Dtos.SubjectDtos;
using SchoolWebApi.Models;

namespace SchoolWebApi
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectDto>();
            CreateMap<CreateSubjectDto, Subject>();
            CreateMap<UpdateSubjectDto, Subject>();
        }
    }
}
