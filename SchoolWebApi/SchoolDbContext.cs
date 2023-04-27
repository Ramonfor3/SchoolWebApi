using Microsoft.EntityFrameworkCore;
using SchoolWebApi.Models;

namespace School
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }   
        public DbSet<Teacher> Teachers { get; set; }   
        public DbSet<Subject> Subjects { get; set; }   
        public DbSet<Career> Careers { get; set; }   
        public DbSet<Section> Sections { get; set; }   
    }
}
