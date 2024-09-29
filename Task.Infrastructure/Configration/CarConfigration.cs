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
    public class CarConfigration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.PlateNumber);
            builder.Property(x => x.Color).IsRequired();
            builder.Property(x => x.Model).IsRequired();
            builder.Property(x => x.ManufacturerYear).IsRequired();
            builder.Property(x => x.Brand).IsRequired();
           
        }
    }
}
