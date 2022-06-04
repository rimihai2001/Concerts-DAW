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
    public class BandRepository : IBandRepository
    {
        private readonly AppDbContext _context;

        public BandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Band band)
        {
            await _context.Bands.AddAsync(band);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Band band)
        {
            _context.Bands.Remove(band);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BandModels>> GetAll()
        {
            var bands = await (await GetAllQuery()).ToListAsync();
            var list = new List<BandModels>();
            foreach (var band in bands)
            {
                var bandModel = new BandModels { BandName = band.BandName };
                list.Add(bandModel);
            }

            return list;
        }

        public async Task<IQueryable<Band>> GetAllQuery()
        {
            var query = _context.Bands.AsQueryable();

            return query;
        }

        public async Task<Band> GetById(int id)
        {
            var band = await _context.Bands.FindAsync(id);

            return band;
        }

        public async Task Update(Band band)
        {
            _context.Bands.Update(band);
            await _context.SaveChangesAsync();
        }
    }
}
