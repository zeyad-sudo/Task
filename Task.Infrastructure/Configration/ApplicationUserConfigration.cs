using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Entities;

namespace Task.Infrastructure.Configration
{
    internal class ApplicationUserConfigration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdentityNumber).IsRequired();
            builder.HasMany(x => x.Cars).WithOne(x => x.ApplicationUser).HasForeignKey(x => x.ApplicationUserId);
        }
    }
}
