using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Bookings.Command.CreateBooking;

namespace TravelOoty.Application.Features.Bookings.Command.UpdateBooking
{
    public class UpdateBookingCommand : IRequest
    {
        public int BookingId { get; set; }
        public List<RoomBookingDto> RoomBookings { get; set; }
        public DateTime CheckIn { get; set; } = DateTime.UtcNow;
        public DateTime CheckOut { get; set; } = DateTime.UtcNow;
        public bool PaymentStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string ConfirmEmailId { get; set; }
        public string ArrivalTime { get; set; }
        public string SpecialRequest { get; set; }
        public decimal TotalAmount { get; set; }
        public bool? isBlocked { get; set; }
    }
}
