using DAW_Backend.DAL.Entities;
using DAW_Backend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.DAL.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<AddressModels>> GetAll();
        Task<Address> GetById(int id);
        Task Create(Address address);
        Task Update(Address address);
        Task Delete(Address address);
        Task<IQueryable<Address>> GetAllQuery();
    }
}
