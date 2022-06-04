using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.BLL.Interfaces
{
    public interface IAddressManager
    {
        Task<List<String>> ModifyAddress();
    }
}
