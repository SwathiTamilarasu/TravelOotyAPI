using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Bookings.Query;

namespace TravelOoty.Application.Features.Bookings.Command.SendBookingDetails
{
    public class SendBookingDetailsCommand : IRequest<BookingVM>
    {
        public int BookingId { get; set; }

        public SendBookingDetailsCommand(int bookingId)
        {
            BookingId = bookingId;
        }
    }
}
