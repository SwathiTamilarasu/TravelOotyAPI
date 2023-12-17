using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Common;

namespace TravelOoty.Domain.Entities
{
    public class PropertyImageDetails: AuditableEntity
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
            
    }
}
