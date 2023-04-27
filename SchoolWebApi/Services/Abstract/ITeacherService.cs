using SchoolWebApi.Dtos.TeachersDto;

namespace SchoolWebApi.Services.Abstract
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetAllAsync();
        Task<TeacherDto> FindByIdAsync(int id);
        Task<TeacherDto> InsertAsync(CreateTeacherDto model);
        Task<TeacherDto> Update(UpdateTeacherDto model, int id);
        void Delete(int id);
    }
}
