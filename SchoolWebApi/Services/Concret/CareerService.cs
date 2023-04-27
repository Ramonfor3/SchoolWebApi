using AutoMapper;
using SchoolWebApi.Dtos.CarrerDtos;
using SchoolWebApi.Exeptions;
using SchoolWebApi.Models;
using SchoolWebApi.Repository.Abstract;
using SchoolWebApi.Response;
using SchoolWebApi.Services.Abstract;

namespace SchoolWebApi.Services.Concret
{
    public class CareerService : ICareerService
    {
        private readonly ICareerRepository _schoolRepository;
        private readonly IMapper _mapper;

        public CareerService(ICareerRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        public async Task<CareerDto> InsertAsync(CreateCareerDto model)
        {
            var career = await _schoolRepository.InsertAsync(_mapper.Map<Career>(model));
            return _mapper.Map<CareerDto>(career);
        }

        public async Task<ApiResponse<CareerDto>> GetAllAsync()
        {
            var apiResponse = new ApiResponse<CareerDto>();
            var career = _mapper.Map<IEnumerable<CareerDto>>(await _schoolRepository.GetAllAsync());
            apiResponse.result = new ResultBody<CareerDto>
            {
                items = career.ToList(),
                totalAcount = career.Count(),

            };
            return apiResponse;
        }

        public async Task<CareerDto> FindByIdAsync(int id)
        {
            var career = await _schoolRepository.FindByIdAsync(id);
            if (career == null) throw new NotFoundException($"Career with ID: {id} not found");
            return _mapper.Map<CareerDto>(career);
        }

        public async Task<CareerDto> Update(UpdateCareerDto model, int id)
        {
            //var student = await _schoolRepository.FindByIdAsync(id);
            //student =  _schoolRepository.Update( _mapper.Map<Student>(model));
            ////if (id != model.Id) throw new Exception("Id not match");
            //return  _mapper.Map<StudentDto>(student);

            if (id != model.Id) throw new NotFoundException($"ID: {id} not match");
            var career = await _schoolRepository.FindByIdAsync(id);
            if (career == null) throw new NotFoundException($"Career with ID: {id} not found");
            career = _schoolRepository.Update(_mapper.Map(model, career));
            return _mapper.Map<CareerDto>(career);
        }

        public void Delete(int id)
        {
            var career = _schoolRepository.FindById(id);
            if (career == null) throw new NotFoundException($"Career with ID: {id} not found");
            career.IsDeleted = true;
            _schoolRepository.Delete(career);
        }
    }
}
