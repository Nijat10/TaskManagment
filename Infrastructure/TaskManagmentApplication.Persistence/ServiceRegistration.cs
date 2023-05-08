using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.Application.Interfaces.Repository;
using TaskManagmentApplication.Persistence.Repositories;

namespace TaskManagmentApplication.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAssignerRepository, AssignerRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
        }
    }
}
