using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.Application.Interfaces.Service;
using TaskManagmentApplication.Application.Services;

namespace TaskManagmentApplication.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IExerciseService, ExerciseService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IImageService, ImageService>();
        }
    }
}
