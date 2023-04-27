using AutoMapper;
using SchoolWebApi.Dtos.CarrerDtos;
using SchoolWebApi.Models;

namespace SchoolWebApi
{
    public class CareerProfile : Profile
    {
        public CareerProfile()
        {
            CreateMap<Career, CareerDto>();
            CreateMap<CreateCareerDto, Career>();
            CreateMap<UpdateCareerDto, Career>();
        }
    }
}
