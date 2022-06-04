using DAW_Backend.BLL.Interfaces;
using DAW_Backend.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.BLL.Managers
{
    public class AddressManager : IAddressManager
    {
        private readonly IAddressRepository _addressRepo;

        public AddressManager(IAddressRepository addressRepo)
        {
            _addressRepo = addressRepo;
        }


        public async Task<List<string>> ModifyAddress()
        {
            var addresses = await _addressRepo.GetAll();
            var list = new List<String>();

            foreach(var address in addresses)
            {
                list.Add($"Street and Number: {address.StreetNumber}, City: {address.City}, Country: {address.Country}");
            }

            return list;
        }
    }
}
