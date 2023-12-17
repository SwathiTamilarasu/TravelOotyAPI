using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Rooms.Query.GetAllRoomsByPropertyId
{
    public class GetRoomQueryByProperty: IRequest<List<RoomVM>>
    {
        public string PropertyId { get; set; }

        public GetRoomQueryByProperty(string propertyId)
        {
            PropertyId = propertyId;
        }

    }
}
