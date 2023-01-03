using Dtos;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.Dtos;
using Zsoft.GenericRepositoryLibrary;

namespace Services.Abstract
{
    public interface ISchoolService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto> FindByIdAsync(int id);
        Task<StudentDto> InsertAsync(CreateStudentDto model);
        Task<StudentDto> Update(UpdateStudentDto model, int id);
        void Delete(int id);

    }
}
