using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Models.Profile
{
    public class ResetPasswordRequest
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]     
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        
        
    }
}
