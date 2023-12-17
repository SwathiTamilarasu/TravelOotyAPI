using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Common;

namespace TravelOoty.Domain.Entities
{
    public class PropertyType: AuditableEntity
    {
        public int PropertyTypeId { get; set; } 
        public string Name { get; set; }

    }
}
