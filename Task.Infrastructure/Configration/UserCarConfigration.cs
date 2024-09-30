using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsk.Data.Entities;

namespace Tsk.Infrastructure.Configration
{
    public class UserCarConfigration : IEntityTypeConfiguration<UserCar>
    {
        public void Configure(EntityTypeBuilder<UserCar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ApplicationUserID).IsRequired();
            builder.Property(x => x.CarPlateNumber).IsRequired();
            builder.Property(x => x.AssignDate).IsRequired();
            builder.Property(x => x.LastMeterReading).IsRequired();
            builder.HasOne(x => x.car).WithMany().HasForeignKey(x => x.CarPlateNumber);
            builder.HasOne(x => x.applicationUser).WithMany().HasForeignKey(x => x.ApplicationUserID);
        }
    }
}
