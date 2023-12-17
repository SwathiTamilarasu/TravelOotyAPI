using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.PropertyAmenitiesLink.Command
{
    public class PropertyAmenitiesLinkDto
    {
        public int AmenitiesId { get; set; }
        public int PropertyID { get; set; }
        public string Name { get; set; }
    }
}
