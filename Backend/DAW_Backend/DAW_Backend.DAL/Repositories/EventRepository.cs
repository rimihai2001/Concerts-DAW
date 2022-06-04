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
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Event ev)
        {
            await _context.Events.AddAsync(ev);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Event ev)
        {
            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EventModels>> GetAll()
        {
            var events = await (await GetAllQuery()).ToListAsync();
            var list = new List<EventModels>();
            foreach (var ev in events)
            {
                var evModel = new EventModels { EventName = ev.EventName };
                list.Add(evModel);
            }

            return list;
        }

        public async Task<IQueryable<Event>> GetAllQuery()
        {
            var query = _context.Events.AsQueryable();

            return query;
        }

        public async Task<Event> GetById(int id)
        {
            var ev = await _context.Events.FindAsync(id);

            return ev;
        }

        public async Task Update(Event ev)
        {
            _context.Events.Update(ev);
            await _context.SaveChangesAsync();
        }
    }
}
