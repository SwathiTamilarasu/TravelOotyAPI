using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Bookings.Query.GetBookingByPropId
{
    public class GetBookingQueryByPropId: IRequest<List<BookingVM>>
    {
        public int PropertyId { get; set; }

        public GetBookingQueryByPropId(int propertyId)
        {
            PropertyId = propertyId;
        }
    }
}
