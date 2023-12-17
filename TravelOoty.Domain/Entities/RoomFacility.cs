using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Common;

namespace TravelOoty.Domain.Entities
{
    public class RoomFacility: AuditableEntity
    {
        public int RoomFacilityId { get; set; }
        public string Name { get; set; }
               
        public List<RoomFacilityLink> FacilityJoins { get; set; }    

        
    }
}
