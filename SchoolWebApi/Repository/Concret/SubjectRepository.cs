using Microsoft.EntityFrameworkCore;
using School;
using SchoolWebApi.Models;
using SchoolWebApi.Repository.Abstract;
using Zsoft.GenericRepositoryLibrary;

namespace SchoolWebApi.Repository.Concret
{
    public class SubjectRepository : GenericRepository<SchoolDbContext, Subject>, ISubjectRepository
    {
        private readonly SchoolDbContext context;

        public SubjectRepository(SchoolDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await context.Subjects.ToListAsync();

        }

        public override async Task<Subject> FindByIdAsync(object Id)
        {
            return await context.Subjects.FindAsync(Id);
        }

        public override async Task<Subject> InsertAsync(Subject entity)
        {

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override Subject Update(Subject entity)
        {
            context.Update(entity);
            context.SaveChangesAsync();
            return entity;
        }

        public override void Delete(Subject entity)
        {
            context.Remove(entity);
            context.SaveChangesAsync();
        }
    }
}
