using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tsk.Application.Helpers.ValidationHelper;
using Tsk.Application.Interfaces;
using Tsk.Application.Services;

namespace Tsk.Application
{
    public static class Application
    {
        public static void Application_CS(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IUserCarService, UserCarService>();
            services.AddScoped<ICarService, CarService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
