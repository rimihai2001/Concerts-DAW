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
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Address address)
        {
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AddressModels>> GetAll()
        {
            var addresses = await (await GetAllQuery()).ToListAsync();
            var list = new List<AddressModels>();
            foreach(var address in addresses)
            {
                var addressModel = new AddressModels { StreetNumber = address.StreetNumber, City = address.City, Country = address.Country };
                list.Add(addressModel);
            }

            return list;
        }

        public async Task<IQueryable<Address>> GetAllQuery()
        {
            var query = _context.Addresses.AsQueryable();

            return query;
        }

        public async Task<Address> GetById(int id)
        {
            var address = await _context.Addresses.FindAsync(id);

            return address;
        }

        public async Task Update(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }
    }
}
