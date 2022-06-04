using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.DAL.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int UpVotes { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
