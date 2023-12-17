using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Bookings.Query.GetRoomBookingsByDate
{
    public class GetRoomBookingByDate: IRequest<List<BookingVM>>
    {
        public int RoomId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public GetRoomBookingByDate(int propertyId, DateTime fromDate, DateTime toDate)
        {
            RoomId = propertyId;
            FromDate = fromDate;
            ToDate = toDate;

        }

    }
}
