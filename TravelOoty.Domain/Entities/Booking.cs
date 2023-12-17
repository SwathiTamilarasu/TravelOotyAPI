using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Domain.Common;

namespace TravelOoty.Domain.Entities
{
    public class Booking: AuditableEntity
    {
        public int BookingId { get; set; }              
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
        public bool IsBookingExpired { get; set; }
        public decimal TotalAmount { get; set; }
        public List<RoomBookingLink> RoomBookings { get; set; }
        public bool? isBlocked { get; set; }
        public bool PayAtHotel { get; set; }
    }
}
