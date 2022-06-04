using DAW_Backend.DAL.Entities;
using DAW_Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.DAL.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<LocationModels>> GetAll();
        Task<Location> GetById(int id);
        Task Create(Location location);
        Task Update(Location location);
        Task Delete(Location location);
        Task<IQueryable<Location>> GetAllQuery();
    }
}
