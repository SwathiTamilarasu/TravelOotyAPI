using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Bookings.Query
{
    public class GetBookingQuery: IRequest<List<BookingVM>>
    {
    }
}
