using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using School;
using SchoolWebApi.Models;
using System.Linq.Expressions;
using Zsoft.GenericRepositoryLibrary;

namespace Repository.Concret
{
    public class SchoolRepository : GenericRepository<SchoolDbContext, Student>, ISchoolRepository
    {
        private readonly SchoolDbContext context;

        public SchoolRepository(SchoolDbContext context): base(context)
        {
            this.context = context;
        }

        public async override Task<Student> InsertAsync(Student entity)
        {
            await context.Students.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public override async Task<IEnumerable<Student>> GetAllAsync()
        { 
            return await context.Students.ToListAsync();
        }



        public async Task<Student> FindById(int id)
        {
            return await context.Students.FindAsync(id);
        }


        public async Task<Student> Update(int id,Student entity)
        {
            context.Students.Update(entity);
            await context.SaveChangesAsync();

            return entity; 
        }

    }
}
