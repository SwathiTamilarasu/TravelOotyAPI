using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Bookings.Command.CreateBooking
{
    public class RoomBookingDto
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int NumberOfRooms { get;set; }
        public string PropertyName { get; set; }
    }
}
