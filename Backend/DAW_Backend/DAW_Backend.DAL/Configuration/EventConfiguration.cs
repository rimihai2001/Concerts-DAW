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
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EventName).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.StartDate).HasColumnType("nvarchar(10)").HasMaxLength(10);
            builder.Property(x => x.Tickets).HasColumnType("int");
        }
    }
}
