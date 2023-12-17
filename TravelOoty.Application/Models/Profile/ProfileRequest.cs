using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Models.Profile
{
    public class ProfileRequest
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
      
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
     
        public string Address { get; set; }
        public bool isEmployee { get; set; }
        public string AadharCardProof { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
