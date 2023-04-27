using AutoMapper;
using SchoolWebApi.Dtos.SectionDtos;
using SchoolWebApi.Models;

namespace SchoolWebApi
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionDto>();
            CreateMap<CreateSectionDto, Section>();
            CreateMap<CreateSectionDto, Section>();
        }
    }
}
