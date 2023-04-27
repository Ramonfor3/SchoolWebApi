using Microsoft.EntityFrameworkCore;
using School;
using SchoolWebApi.Models;
using SchoolWebApi.Repository.Abstract;
using Zsoft.GenericRepositoryLibrary;

namespace SchoolWebApi.Repository.Concret
{
    public class SectionRepository : GenericRepository<SchoolDbContext, Section>, ISectionRepository
    {
        private readonly SchoolDbContext context;

        public SectionRepository(SchoolDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<IEnumerable<Section>> GetAllAsync()
        {
            return await context.Sections.ToListAsync();

        }

        public override async Task<Section> FindByIdAsync(object Id)
        {
            return await context.Sections.FindAsync(Id);
        }

        public override async Task<Section> InsertAsync(Section entity)
        {

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override Section Update(Section entity)
        {
            context.Update(entity);
            context.SaveChangesAsync();
            return entity;
        }

        public override void Delete(Section entity)
        {
            context.Remove(entity);
            context.SaveChangesAsync();
        }
    }
}
