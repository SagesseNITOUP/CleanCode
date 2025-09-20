using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student.Application.Commands.GetStudent;
using Student.Persistence.DatabaseContext;

namespace Student.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<GetStudentQueryHandler>();
            });

            services.AddDbContext<ServiceDatabaseContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("StudentConnectionString"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("StudentConnectionString"))
                ));


            return services;
        }



    }
}
