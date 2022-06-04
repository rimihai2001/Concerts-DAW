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
    public class BandConfiguration : IEntityTypeConfiguration<Band>
    {
        public void Configure(EntityTypeBuilder<Band> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BandName).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.MusicGenre).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.YearFounded).HasColumnType("int").HasMaxLength(4);
        }
    }
}
