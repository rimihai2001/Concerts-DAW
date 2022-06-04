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
    public class BandEventConfiguration : IEntityTypeConfiguration<BandEvent>
    {
        public void Configure(EntityTypeBuilder<BandEvent> builder)
        {
            builder.HasOne(x => x.Band).WithMany(x => x.BandEvents).HasForeignKey(x => x.BandId);
            builder.HasOne(x => x.Event).WithMany(x => x.BandEvents).HasForeignKey(x => x.EventId);
        }
    }
}
