using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using School;
using SchoolWebApi.Models;
using System.Linq.Expressions;
using Zsoft.GenericRepositoryLibrary;

namespace Repository.Concret
{
    public class StudentRepository : GenericRepository<SchoolDbContext, Student>, IStudentRepository
    {
        private readonly SchoolDbContext context;

        public StudentRepository(SchoolDbContext context): base(context)
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


        public override async Task<Student> FindByIdAsync(object Id)
        {
            return await context.Students.FindAsync(Id);
        }

        public override void Delete(Student entity)
        {
            context.Students.Update(entity);
            context.SaveChanges();

        }

        public override Student Update(Student entity)
        {
            context.Students.Update(entity);
            context.SaveChangesAsync();

            return entity; 
        }

    }
}
