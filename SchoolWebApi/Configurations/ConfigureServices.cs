﻿using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Concret;
using School;
using Services.Abstract;
using Services.Concret;

namespace Configurations
{

    public static class ConfigureServices
    {
        public static void ConfigureService(this IServiceCollection service, IConfiguration configuration)
        {
            //service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //service.AddTransient<ISchoolRepository, SchoolRepository>();
            //service.AddTransient<ISchoolService, SchoolService>();

        }
    }
}
