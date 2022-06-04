using DAW_Backend.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.DAL.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StreetNumber).HasColumnType("nvarchar(200)").HasMaxLength(200);
            builder.Property(x => x.Country).HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.Property(x => x.City).HasColumnType("nvarchar(50)").HasMaxLength(50);
        }
    }
}
