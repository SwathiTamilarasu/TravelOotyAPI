using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Common;

namespace TravelOoty.Domain.Entities
{
    public class RoomFacilityLink: AuditableEntity
    {
        public int RoomFacilityId { get; set; }
        public RoomFacility RoomFacility { get; set; }
        public int RoomId { get; set; }
        public Rooms Rooms { get; set; }
    }
}
