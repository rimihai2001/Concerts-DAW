using DAW_Backend.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Backend.DAL
{
    public class InitialSeed
    {
        private readonly RoleManager<Role> _roleManager;

        public InitialSeed(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void CreateRoles()
        {
            string[] roleNames = {
                                "Admin",
                                "User"
                                };

            foreach (var roleName in roleNames)
            {
                var role = new Role
                {
                    Name = roleName
                };
                _roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
