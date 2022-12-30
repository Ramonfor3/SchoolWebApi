using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Concret;
using School;
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

            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            




        }
    }
}
