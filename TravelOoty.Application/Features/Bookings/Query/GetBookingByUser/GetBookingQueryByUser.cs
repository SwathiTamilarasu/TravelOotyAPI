using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Bookings.Query.GetBookingByUser
{
    public class GetBookingQueryByUser : IRequest<List<BookingVM>>
    {
        public string UserId { get; set; }
        public bool IsEmployee { get; set; }

        public GetBookingQueryByUser(string userId,bool isEmployee)
        {
            UserId = userId;
            IsEmployee = isEmployee;
        }
    }
}
