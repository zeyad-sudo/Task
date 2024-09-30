using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using Tsk.Application.Helpers.JWT;
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
            //ojects life time management
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IUserCarService, UserCarService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAuthService, AuthService>();

            //jwt
            services.Configure<JwtHelper>(Configuration.GetSection("JWT"));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        //ValidIssuer = Configuration["JWT:Issuer"],
                        //ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                    };
                });
            //identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders()
                .AddTokenProvider<EmailTokenProvider<ApplicationUser>>(TokenOptions.DefaultEmailProvider);

            //validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
