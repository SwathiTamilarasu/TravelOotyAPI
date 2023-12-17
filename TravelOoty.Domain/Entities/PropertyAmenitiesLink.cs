using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Common;

namespace TravelOoty.Domain.Entities
{
    public class PropertyAmenitiesLink: AuditableEntity
    {
        public int AmenitiesId { get; set; }
        public Amenities Amenities { get; set; }
        public int PropertyID { get; set; }
        public Property Property { get; set; }
    }
}
