using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task.Infrastructure.Contexts;
namespace Task.Infrastructure
{
    public static class Infrastructure
    {
        public static void Infrastructure_CS(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IResrvationRepo, ReservationRepo>();
            services.AddDbContext<Context>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });
        }
    }
}
