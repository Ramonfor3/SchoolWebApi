using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstract;
using School;
using SchoolWebApi.Dtos;
using SchoolWebApi.Models;
using Services.Abstract;
using Zsoft.GenericRepositoryLibrary;

namespace Services.Concret
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;

        public SchoolService(ISchoolRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        public async Task<StudentDto> InsertAsync(CreateStudentDto model)
        {
            var student = await _schoolRepository.InsertAsync(_mapper.Map<Student>(model));
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StudentDto>>(await _schoolRepository.GetAllAsync());
        }

        public async Task<StudentDto> FindByIdAsync(int id)
        {
            var student = await _schoolRepository.FindByIdAsync(id);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> Update(UpdateStudentDto model, int id)
        {
            //var student = await _schoolRepository.FindByIdAsync(id);
            //student =  _schoolRepository.Update( _mapper.Map<Student>(model));
            ////if (id != model.Id) throw new Exception("Id not match");
            //return  _mapper.Map<StudentDto>(student);

            if (id != model.Id) throw new Exception("It's doesn't exist");
            var student = await _schoolRepository.FindByIdAsync(id);
            if (student == null) throw new Exception("Student not found");
            student =  _schoolRepository.Update(_mapper.Map(model, student));
            return _mapper.Map<StudentDto>(student);
        }

        public void  Delete(int id)
        {
            var student =  _schoolRepository.FindById(id);
            if (student == null) throw new Exception("It's doesn't exist");
            student.IsDeleted = true;
            _schoolRepository.Delete(student);
        }
    }
}
