using Microsoft.EntityFrameworkCore;
using School;
using SchoolWebApi.Models;
using SchoolWebApi.Repository.Abstract;
using Zsoft.GenericRepositoryLibrary;

namespace SchoolWebApi.Repository.Concret
{
    public class TeacherRepository : GenericRepository<SchoolDbContext, Teacher>, ITeacherRepository
    {
        private readonly SchoolDbContext context;

        public TeacherRepository(SchoolDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await context.Teachers.ToListAsync();
            
        }

        public override async Task<Teacher> FindByIdAsync(object Id)
        {
            return await context.Teachers.FindAsync(Id);
        }

        public override async Task<Teacher> InsertAsync(Teacher entity)
        {

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override  Teacher Update(Teacher entity)
        {
            context.Update(entity);
            context.SaveChangesAsync();
            return entity;
        }

        public override void Delete(Teacher entity)
        {
            context.Remove(entity);
            context.SaveChangesAsync();
        }
    }
}
