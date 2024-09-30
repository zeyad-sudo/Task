using Tsk.Infrastructure;
using Tsk.Application;
using Tsk.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
namespace Tsk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.Infrastructure_CS(builder.Configuration);
            builder.Services.Application_CS(builder.Configuration);
            builder.Services.AddDbContext<Context>(
                               options =>
                               {
                                   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                               });  
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(corsoption =>
            {
                corsoption.AddPolicy("MyPolicy", corspolicybuilder =>
                {
                    corspolicybuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    //.withorigins(" domain");
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
