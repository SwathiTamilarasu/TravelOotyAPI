using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Models.Profile;
using TravelOoty.Identity.Models;

namespace TravelOoty.Identity.Interface
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAllAsync(bool onlyEmployee);

        //Task<int> GetCountAsync();

        //Task<ApplicationUser> GetAsync(string userId);
    }
}
