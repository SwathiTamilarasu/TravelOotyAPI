using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Common;

namespace TravelOoty.Domain.Entities
{
    public class Rooms: AuditableEntity
    {
        public int RoomId { get; set; }
        public Property Property { get; set; }
        public int PropertyID { get; set; }
        public string Name { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal SpecialPrice { get; set; }
        public RoomCategory RoomCategory { get; set; }
        public int RoomCategoryId { get; set; }
        public int Guests { get; set; }
        public int Beds { get; set; }        
        public List<RoomFacilityLink> FacilityJoins { get; set; }
        public List<RoomBookingLink> RoomBookings { get; set; }
        public string NumberOfRoomsCategory { get; set; }
        public string CancellationPolicy { get; set; }

    }
}
