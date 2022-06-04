using DAW_Backend.DAL.Entities;
using DAW_Backend.DAL.Interfaces;
using DAW_Backend.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.DAL.Repositories
{
    class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Location l)
        {
            await _context.Locations.AddAsync(l);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Location l)
        {
            _context.Locations.Remove(l);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LocationModels>> GetAll()
        {
            var locations = await (await GetAllQuery()).ToListAsync();
            var list = new List<LocationModels>();
            foreach (var l in locations)
            {
                var lModel = new LocationModels { Name = l.Name };
                list.Add(lModel);
            }

            return list;
        }

        public async Task<IQueryable<Location>> GetAllQuery()
        {
            var query = _context.Locations.AsQueryable();

            return query;
        }

        public async Task<Location> GetById(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            return location;
        }

        public async Task Update(Location l)
        {
            _context.Locations.Update(l);
            await _context.SaveChangesAsync();
        }
    }

}
