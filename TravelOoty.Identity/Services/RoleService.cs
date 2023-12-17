using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Identity;
using TravelOoty.Application.Models.Authentication;
using TravelOoty.Identity.Models;

namespace TravelOoty.Identity.Services
{
    public class RoleService:IRoleService
    {
        private RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public RoleService(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public List<RoleRequest> GetAllRoles()
        {
            var result = _roleManager.Roles.ToList();
            var roleRequest = new List<RoleRequest>();
            foreach (var role in result) 
            {
                roleRequest.Add(
                   new RoleRequest { Id = role.Id, Name = role.Name }
                );
            }
             return roleRequest;
        }
        public async Task AddRoleAsync(string roleName)
        {
            
                var identityRole = new ApplicationRole();
                bool result = await _roleManager.RoleExistsAsync(roleName);
                if (!result)
                {
                    identityRole.Name = roleName;
                }
                await _roleManager.CreateAsync(identityRole);                    
        }

        public async Task UpdateRoleAsync(string roleId,string roleName)
        {
            var identityRole = new ApplicationRole
            {
                Name = roleName,
                Id=roleId,
            };
          var result=  await _roleManager.UpdateAsync(identityRole);
        }
        public async Task DeleteRoleAsync(string roleId,string roleName)
        {
            var identityRole = new ApplicationRole
            {
                Name = roleName,
                Id =   roleId
            };

          var result=  await _roleManager.DeleteAsync(identityRole);
        }
        public async Task AddRoleToUserAsync(string roleName,string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception($"Something went wrong.");
            }
            else{
               await _userManager.AddToRoleAsync(user, roleName);
            }

        }
        public async Task RemoveRoleForUserAsync(string roleName, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception($"Something went wrong.");
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, roleName);
            }
        }
    }
}
