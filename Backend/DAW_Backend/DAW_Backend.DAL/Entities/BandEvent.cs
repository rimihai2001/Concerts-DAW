using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.DAL.Entities
{
    public class BandEvent
    {
        public int Id { get; set; }
        public int BandId { get; set; }
        public int EventId { get; set; }
        public virtual Band Band { get; set; }
        public virtual Event Event { get; set; }
    }
}
