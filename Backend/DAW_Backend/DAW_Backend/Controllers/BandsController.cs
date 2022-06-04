using DAW_Backend.DAL;
using DAW_Backend.DAL.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Backend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BandsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost("AddBand")]
        public async Task<IActionResult> AddBand([FromBody] Band band)
        {
            if (string.IsNullOrEmpty(band.BandName))
            {
                return BadRequest("Band name is null");
            }
            if (string.IsNullOrEmpty(band.MusicGenre))
            {
                return BadRequest("Band music genre is null");
            }
            
            await _context.Bands.AddAsync(band);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetBand([FromRoute] int id)
        {
            var band = await _context.Bands.Include(x => x.BandEvents)
                .Where(x => x.Id == id)
                .ToListAsync();

            return Ok(band);
        }

        [HttpGet("get-group-by-year/{year}")]
        public async Task<IActionResult> GetGroupByYear([FromRoute] int year)
        {
            var years = _context.Bands
                .GroupBy(x => x.YearFounded)
                .Where(x => x.Key >= year)
                .Select(x => new
                {
                    Key = x.Key,
                    Count = x.Count()
                }).ToList();

            return Ok(years);
        }
        [HttpGet("Get-select")]
        public async Task<IActionResult>  GetBandSelect()
        {
            var bands = await _context.Bands.Select(x => new { Id = x.Id, bandName = x.BandName, musicGenre = x.MusicGenre, yearFounded = x.YearFounded }).ToListAsync();

            return Ok(bands);

        }



        [HttpPut]
        public async Task<IActionResult> UpdateBandName([FromQuery] int id, [FromQuery] string newName)
        {
            var band = await _context.Bands.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            band.BandName = newName;

            _context.Entry(band).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok();
        }

        
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBand([FromRoute] int id)
        {
            var band = await _context.Bands.FindAsync(id);
            if (band == null)
            {
                return NotFound();
            }

            _context.Bands.Remove(band);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
