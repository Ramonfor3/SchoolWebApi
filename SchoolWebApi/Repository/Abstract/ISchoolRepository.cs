using Dtos;
using SchoolWebApi.Dtos;
using SchoolWebApi.Models;
using Zsoft.GenericRepositoryLibrary;

namespace Repository.Abstract
{
    public interface ISchoolRepository: IGenericRepository<Student>
    {
        //public Task<Student> InsertAsync(Student entity);
        //public Task<IEnumerable<Student>> GetAllAsync();
        //public Task<Student> FindByIdAsync(object Id);
        //public Task<Student> Update(Student entity);
    }
}
