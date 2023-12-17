using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Bookings.Command.CreateBooking
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public List<RoomBookingDto> RoomBookings { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool PaymentStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string ConfirmEmailId { get; set; }
        public string ArrivalTime { get; set; }
        public string SpecialRequest { get; set; }
        public bool? isBlocked { get; set; }
    }
}
