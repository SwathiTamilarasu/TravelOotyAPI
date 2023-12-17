using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }        
        public bool isEmployee { get; set; }
        public string AadharCardProof { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }

    }
}
