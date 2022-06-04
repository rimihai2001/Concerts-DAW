using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.DAL.Entities
{
    public class Band
    {
        [Key]
        public int Id { get; set; }
        public string BandName { get; set; }
        public string MusicGenre { get; set; }
        public int YearFounded { get; set; }
        public virtual ICollection<BandEvent> BandEvents { get; set; }
    }
}
