using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.Bookings.Command.CreateBooking
{
    public class CreateBookingResponse: BaseResponse
    {
        public CreateBookingResponse() : base()
        {

        }
        public BookingDto BookingDto { get; set; }
    }
}
