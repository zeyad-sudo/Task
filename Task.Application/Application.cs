using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tsk.Application.Helpers.ValidationHelper;
using Tsk.Application.Interfaces;
using Tsk.Application.Services;
using Tsk.Data.Entities;
using Tsk.Infrastructure.Contexts;

namespace Tsk.Application
{
    public static class Application
    {
        public static void Application_CS(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IUserCarService, UserCarService>();
            services.AddScoped<ICarService, CarService>();


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders()
                .AddTokenProvider<EmailTokenProvider<ApplicationUser>>(TokenOptions.DefaultEmailProvider);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
