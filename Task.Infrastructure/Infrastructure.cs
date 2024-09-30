using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tsk.Infrastructure.Contexts;
using Tsk.Infrastructure.Repositories.Generics;
using Tsk.Infrastructure.Repositories.UnitOfWork;
namespace Tsk.Infrastructure
{
    public static class Infrastructure
    {
        public static void Infrastructure_CS(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddDbContext<Context>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });
        }
    }
}
