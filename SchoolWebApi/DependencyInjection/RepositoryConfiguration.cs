using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Concret;
using School;
using SchoolWebApi.Repository.Abstract;
using SchoolWebApi.Repository.Concret;
using SchoolWebApi.Services.Abstract;
using SchoolWebApi.Services.Concret;
using Services.Abstract;
using Services.Concret;

namespace DependencyInjection
{
    public static class RepositoryConfiguration
    {
        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<SchoolDbContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("defaultConnection"));


            });

            //Students
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            //Teachers
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            //Career
            services.AddScoped<ICareerService, CareerService>();
            services.AddScoped<ICareerRepository, CareerRepository>();

            //Subject
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();

            //Section
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<ISectionRepository, SectionRepository>();


            //AutoMapper Injection
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            




        }
    }
}
