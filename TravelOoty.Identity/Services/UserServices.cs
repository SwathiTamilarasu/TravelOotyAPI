using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Identity;
using TravelOoty.Application.Models.Profile;
using TravelOoty.Identity.Interface;
using TravelOoty.Identity.Models;

namespace TravelOoty.Identity.Services
{
    public class UserServices: IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        public UserServices(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public async Task<List<UserResponse>> GetAllAsync(bool onlyEmployee)
        {
            var userDetails= new List<UserResponse>();
            var result = new List<ApplicationUser>();
            if (onlyEmployee)
            {
                result = await _userManager.Users.Include(r => r.UserRoles).Where(e => e.isEmployee).ToListAsync();
            }
            else
            {
                result = await _userManager.Users.Include(r => r.UserRoles).ToListAsync();
            }
            var allRoles= _roleManager.Roles.ToList();
             foreach(var user in result)
            {
                 List<string> roleList=new();

                 foreach(var role in user.UserRoles)
                {
                    roleList.Add(allRoles.Where(e => e.Id == role.RoleId).FirstOrDefault().Name);
                }           
                    userDetails.Add(new UserResponse
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Role = roleList,
                        AadharCardProof = user.AadharCardProof,
                        isEmployee = user.isEmployee,
                        Address = user.Address,
                        Designation = user.Designation,
                        DateOfBirth = user.DateOfBirth,
                        ImageName = user.ImageName,
                        ImagePath = user.ImagePath,
                        PhoneNumber = user.PhoneNumber

                    });
                              
            }
             return userDetails;
        }
    }
}
