using DAW_Backend.DAL;
using DAW_Backend.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EventsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddEvent([FromBody] Event ev)
        {
            if (string.IsNullOrEmpty(ev.EventName))
            {
                return BadRequest("Event Name is null");
            }
            await _context.Events.AddAsync(ev);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            var ev = await _context.Events.Include(x => x.Location)
                .Where(x => x.Id == id)
                .ToListAsync();

            return Ok(ev);
        }

        [HttpGet("get-join-locations")]
        public IActionResult GetJoin()
        {
            var locations = _context.Locations;
            var join = _context.Events.Join(locations, b => b.LocationId, a => a.Id, (b, a) => new
            {
                LocationName = a.Name,
                EventName = b.EventName,
                Date = b.StartDate

            }).ToList();

            return Ok(join);
        }



        [HttpPut]
        public async Task<IActionResult> UpdateEvent([FromQuery] int id, [FromQuery] int tickets)
        {
            var ev = await _context.Events.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            ev.Tickets = tickets;

            _context.Entry(ev).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok();
        }

        




        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null)
            {
                return NotFound();
            }

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
