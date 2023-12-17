using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Models.Authentication;

namespace TravelOoty.Application.Contracts.Identity
{
    public interface IRoleService
    {
        List<RoleRequest> GetAllRoles();
        Task AddRoleAsync(string roleName);
        Task UpdateRoleAsync(string roleId, string roleName);
        Task DeleteRoleAsync(string roleId, string roleName);
        Task AddRoleToUserAsync(string roleId, string userId);
        Task RemoveRoleForUserAsync(string roleId, string userId);
    }
}
