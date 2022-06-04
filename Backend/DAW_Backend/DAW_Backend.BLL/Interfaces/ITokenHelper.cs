using DAW_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.BLL.Interfaces
{
    public interface ITokenHelper
    {
        Task<string> CreateAccessToken(User _User);
        string CreateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string _Token);
    }
}
