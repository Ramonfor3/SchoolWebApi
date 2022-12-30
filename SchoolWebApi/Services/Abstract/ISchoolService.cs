using Dtos;
using SchoolWebApi.Dtos;
using Zsoft.GenericRepositoryLibrary;

namespace Services.Abstract
{
    public interface ISchoolService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto> FindById(int id);
        Task<StudentDto> InsertAsync(CreateStudentDto model);
        Task<StudentDto> Update(int id, UpdateStudentDto model);
    }
}
