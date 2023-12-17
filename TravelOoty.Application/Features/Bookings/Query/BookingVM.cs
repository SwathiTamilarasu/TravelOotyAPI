using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Bookings.Command.CreateBooking;
using TravelOoty.Application.Features.Property.Query.GetProperty;

namespace TravelOoty.Application.Features.Bookings.Query
{
    public class BookingVM
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public string Name { get; set; }
        public List<RoomBookingDto> RoomBookings { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime BookedDate { get; set; }
        public bool PaymentStatus { get; set; }
        public string CreatedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string ConfirmEmailId { get; set; }
        public string ArrivalTime { get; set; }
        public string SpecialRequest { get; set; }
        public decimal TotalAmount { get; set; }
        public int RoomsLeft { get; set; }
        public int? NoOfRoomsSelected { get; set; }
        public bool? isBlocked { get; set; }
        public bool PayAtHotel { get; set;}
    }
}
