using DAW_Backend.DAL.Entities;
using DAW_Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.DAL.Interfaces
{
    public interface IBandRepository
    {
        Task<List<BandModels>> GetAll();
        Task<Band> GetById(int id);
        Task Create(Band band);
        Task Update(Band band);
        Task Delete(Band band);
        Task<IQueryable<Band>> GetAllQuery();
    }
}
