using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Models.Profile
{
    public class UserResponse
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }       
        public string LastName { get; set; }     
        public string Email { get; set; }        
        public string UserName { get; set; }        
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public List<string> Role { get; set;  }
        public string AadharCardProof { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool isEmployee { get; set; }
    }
}
