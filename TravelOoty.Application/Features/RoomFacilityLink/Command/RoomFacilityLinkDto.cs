using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Roomfacilities.Command.CreateRoomFacility;
using TravelOoty.Application.Features.Rooms.Command.CreateRoom;

namespace TravelOoty.Application.Features.RoomFacilityLink.Query
{
    public class RoomFacilityLinkDto
    {
        public int RoomFacilityId { get; set; }
        
        public int RoomId { get; set; }
        
    }
}
