using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstract;
using School;
using SchoolWebApi.Dtos.StudentsDto;
using SchoolWebApi.Exeptions;
using SchoolWebApi.Models;
using SchoolWebApi.Response;
using Services.Abstract;
using Zsoft.GenericRepositoryLibrary;

namespace Services.Concret
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _schoolRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        public async Task<StudentDto> InsertAsync(CreateStudentDto model)
        {
            var student = await _schoolRepository.InsertAsync(_mapper.Map<Student>(model));
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<ApiResponse<StudentDto>> GetAllAsync()
        {
            var apiResponse = new ApiResponse<StudentDto>();
            var student = _mapper.Map<IEnumerable<StudentDto>>(await _schoolRepository.GetAllAsync());
            apiResponse.result = new ResultBody<StudentDto> 
            { 
                items = student.ToList(), 
                totalAcount = student.Count(),

            };
            return apiResponse;
        }

        public async Task<StudentDto> FindByIdAsync(int id)
        {
            var student = await _schoolRepository.FindByIdAsync(id);
            if (student == null) throw new NotFoundException($"Student with ID: {id} not found");
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> Update(UpdateStudentDto model, int id)
        {
            //var student = await _schoolRepository.FindByIdAsync(id);
            //student =  _schoolRepository.Update( _mapper.Map<Student>(model));
            ////if (id != model.Id) throw new Exception("Id not match");
            //return  _mapper.Map<StudentDto>(student);

            if (id != model.Id) throw new NotFoundException($"ID: {id} not match");
            var student = await _schoolRepository.FindByIdAsync(id);
            if (student == null) throw new NotFoundException($"Student with ID: {id} not found");
            student =  _schoolRepository.Update(_mapper.Map(model, student));
            return _mapper.Map<StudentDto>(student);
        }

        public void  Delete(int id)
        {
            var student =  _schoolRepository.FindById(id);
            if (student == null) throw new NotFoundException($"Student with ID: {id} not found");
            student.IsDeleted = true;
            _schoolRepository.Delete(student);
        }
    }
}
