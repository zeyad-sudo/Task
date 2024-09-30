using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsk.Data.Entities;
using Tsk.Infrastructure.Configration;

namespace Tsk.Infrastructure.Contexts
{
    public class Context: IdentityDbContext<ApplicationUser>
    {
        #region Constructors
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }
        #endregion
        #region DBset
        public DbSet<Car> Cars { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserCar> UserCars { get; set; }
        #endregion
        #region Mehods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CarConfigration().Configure(modelBuilder.Entity<Car>());
            new ApplicationUserConfigration().Configure(modelBuilder.Entity<ApplicationUser>());
            new UserCarConfigration().Configure(modelBuilder.Entity<UserCar>());

            base.OnModelCreating(modelBuilder);
         
        } 
        #endregion

    }
}
