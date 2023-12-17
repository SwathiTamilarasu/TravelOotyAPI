using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Models.Authentication
{
    public class RegistrationRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        
        public string PhoneNumber { get; set; }
        public string Address { get;set; }
        public bool isEmployee { get; set; }
        public string AadharCardProof { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfBirth { get; set; }


    }
}
