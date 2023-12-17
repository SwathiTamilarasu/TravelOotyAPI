using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Bookings.Command.CancelBooking
{
    public class CancelBookingById: IRequest
    {
        public int BookingId { get; set; }
    }
}
