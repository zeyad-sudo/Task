using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Entities;
using Task.Infrastructure.Configration;

namespace Task.Infrastructure.Contexts
{
    public class Context: IdentityDbContext<ApplicationUser>
    {
        #region Constructors
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }
        #endregion
        #region DBset
        public DbSet<Car> Cars { get; set; }
        #endregion
        #region Mehods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CarConfigration().Configure(modelBuilder.Entity<Car>());
            new ApplicationUserConfigration().Configure(modelBuilder.Entity<ApplicationUser>());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        } 
        #endregion

    }
}
