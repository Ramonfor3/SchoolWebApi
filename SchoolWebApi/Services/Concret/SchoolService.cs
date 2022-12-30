using AutoMapper;
using Dtos;
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

        public async Task<StudentDto> FindById(int id)
        {
            var student = await _schoolRepository.FindByIdAsync(id);
            return _mapper.Map<StudentDto>(student);
        }


        public async Task<StudentDto> Update(int id,UpdateStudentDto model)
        {
            //if (id != model.Id) throw new Exception("Id not match");
            var student =  _schoolRepository.Update( _mapper.Map<Student>(model));
            return _mapper.Map<StudentDto>(student);
        }

    }
}
