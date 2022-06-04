using DAW_Backend.DAL;
using DAW_Backend.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class AddressesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AddressesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddAddress")]
        public async Task<IActionResult> AddAddress([FromBody] Address address)
        {
            if (string.IsNullOrEmpty(address.StreetNumber))
            {
                return BadRequest("Street and Number are null");
            }

            if (string.IsNullOrEmpty(address.City))
            {
                return BadRequest("City is null");
            }

            if (string.IsNullOrEmpty(address.Country))
            {
                return BadRequest("Country is null");
            }

            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetAddress([FromRoute] int id)
        {
            var address = await _context.Addresses.Where(x => x.Id == id).Include(x => x.Location).FirstOrDefaultAsync();

            return Ok(address);

        }

        [HttpGet("Get-select")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetAddressSelect()
        {
            var address = await _context.Addresses.Select(x => new { Id = x.Id, City = x.City, Country = x.Country }).ToListAsync();

            return Ok(address);

        }

        [HttpGet("Get-join")]
        public async Task<IActionResult> GetAddressJoin()
        {
            var address = await _context.Addresses.Include(x => x.Location).ToListAsync();

            return Ok(address);

        }

        [HttpGet("Get-order-by")]
        public async Task<IActionResult> GetAddressOrderBy()
        {
            var address = await _context.Addresses.Include(x => x.Location).OrderByDescending(x => x.StreetNumber).ToListAsync();

            return Ok(address);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] string str)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);

            address.StreetNumber = str;

            await _context.SaveChangesAsync();

            return Ok(address);

        }

        [HttpGet("jazy-lazy")]
        public async Task<IActionResult> JoinLazy()
        {
            var address = _context.Addresses.AsQueryable();

            return Ok(address);
        }

        [HttpGet("Get-group-by")]
        public async Task<IActionResult> GetGroupBy()
        {
            var address = _context.Addresses.AsQueryable();

            return Ok(address);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
