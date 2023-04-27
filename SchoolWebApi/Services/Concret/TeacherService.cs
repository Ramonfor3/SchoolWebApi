using AutoMapper;
using SchoolWebApi.Dtos.TeachersDto;
using SchoolWebApi.Models;
using SchoolWebApi.Repository.Abstract;
using SchoolWebApi.Services.Abstract;

namespace SchoolWebApi.Services.Concret
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            var teacher = _teacherRepository.FindById(id);
            if (teacher == null) throw new Exception("Teacher not found");
            teacher.IsDeleted = true;
            _teacherRepository.Delete(teacher);
        }

        public async Task<TeacherDto> FindByIdAsync(int id)
        {
            var teacher = await _teacherRepository.FindByIdAsync(id);
            return _mapper.Map<TeacherDto>(teacher);
        }

        public async Task<IEnumerable<TeacherDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<TeacherDto>>(await _teacherRepository.GetAllAsync());
        }

        public async Task<TeacherDto> InsertAsync(CreateTeacherDto model)
        {
            var teacher = await _teacherRepository.InsertAsync(_mapper.Map<Teacher>(model));
            return _mapper.Map<TeacherDto>(teacher);
        }

        public async Task<TeacherDto> Update(UpdateTeacherDto model, int id)
        {
            if (id != model.Id) throw new Exception("It's Doesn't exist");
            var teacher = await _teacherRepository.FindByIdAsync(id);
            if (teacher == null) throw new Exception("Teacher not found");
            teacher = _teacherRepository.Update(_mapper.Map(model, teacher));
            return _mapper.Map<TeacherDto>(teacher);    

        }
    }
}
