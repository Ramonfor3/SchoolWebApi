using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.Dtos.StudentsDto;
using SchoolWebApi.Response;
using Zsoft.GenericRepositoryLibrary;

namespace Services.Abstract
{
    public interface IStudentService
    {
        Task<ApiResponse<StudentDto>> GetAllAsync();
        Task<StudentDto> FindByIdAsync(int id);
        Task<StudentDto> InsertAsync(CreateStudentDto model);
        Task<StudentDto> Update(UpdateStudentDto model, int id);
        void Delete(int id);

    }
}
