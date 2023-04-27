using Microsoft.EntityFrameworkCore;
using School;
using SchoolWebApi.Models;
using SchoolWebApi.Repository.Abstract;
using Zsoft.GenericRepositoryLibrary;

namespace SchoolWebApi.Repository.Concret
{
    public class CareerRepository : GenericRepository<SchoolDbContext, Career>, ICareerRepository
    {
        private readonly SchoolDbContext context;

        public CareerRepository(SchoolDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<IEnumerable<Career>> GetAllAsync()
        {
            return await context.Careers.ToListAsync();

        }

        public override async Task<Career> FindByIdAsync(object Id)
        {
            return await context.Careers.FindAsync(Id);
        }

        public override async Task<Career> InsertAsync(Career entity)
        {

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override Career Update(Career entity)
        {
            context.Update(entity);
            context.SaveChangesAsync();
            return entity;
        }

        public override void Delete(Career entity)
        {
            context.Remove(entity);
            context.SaveChangesAsync();
        }
    }
}
