using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.PropertyImageDetails.Query
{
    public class PropertyImageVM
    {
        public int Id { get; set; }

        public int PropertyId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string Data_url { get; set; }
    }
}
