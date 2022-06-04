using DAW_Backend.BLL.Interfaces;
using DAW_Backend.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesV2Controller : ControllerBase
    {
        private readonly IAddressManager _addressManager;

        public AddressesV2Controller(IAddressManager addressManager)
        {
            _addressManager = addressManager;
        }

        [HttpGet("get-modify")]
        public async Task<IActionResult> GetModify()
        {
            var list = await _addressManager.ModifyAddress();
            return Ok(list);
        }
    }
}
