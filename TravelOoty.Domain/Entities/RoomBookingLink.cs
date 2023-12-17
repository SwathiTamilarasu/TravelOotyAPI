using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Common;

namespace TravelOoty.Domain.Entities
{
    public class RoomBookingLink: AuditableEntity
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public int RoomId { get; set; }
        public Rooms Rooms { get; set; }
        public int NumberOfRooms { get; set; }
    }
}
