using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Rooms.Query.GetAllRoomsByBooking
{
    public class GetRoomQueryByDate: IRequest<List<RoomBookingVM>>
    {
        public string PropertyId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public GetRoomQueryByDate(string propertyId, DateTime fromDate, DateTime toDate)
        {
            PropertyId = propertyId;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
