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
    public class LocationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LocationsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddLocation([FromBody] Location location)
        {
            if (string.IsNullOrEmpty(location.Name))
            {
                return BadRequest("Location Name is null");
            }
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetLocation([FromRoute] int id)
        {
            var location = await _context.Locations.Include(x => x.Address)
                .Where(x => x.Id == id)
                .ToListAsync();

            return Ok(location);
        }



        [HttpPut]
        public async Task<IActionResult> UpdateLocation([FromQuery] int id, [FromQuery] int votes)
        {
            var location = await _context.Locations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            location.UpVotes = votes;

            _context.Entry(location).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok();
        }

        




        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteLocation([FromRoute] int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
