using DAW_Backend.DAL.Entities;
using DAW_Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.DAL.Interfaces
{
    public interface IEventRepository
    {
        Task<List<EventModels>> GetAll();
        Task<Event> GetById(int id);
        Task Create(Event ev);
        Task Update(Event ev);
        Task Delete(Event ev);
        Task<IQueryable<Event>> GetAllQuery();
    }
}
