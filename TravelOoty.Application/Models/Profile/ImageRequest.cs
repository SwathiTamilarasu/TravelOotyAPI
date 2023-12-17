using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Models.Profile
{
    public class ImageRequest
    {
        public string FileName { get; set; }
        public string UserId { get;set; }
        public IFormFile File { get; set; }
    }
}
