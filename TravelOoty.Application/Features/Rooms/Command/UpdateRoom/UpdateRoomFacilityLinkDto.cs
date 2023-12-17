using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Rooms.Command.UpdateRoom
{
    public class UpdateRoomFacilityLinkDto
    {
        public int RoomFacilityId { get; set; }        
        public int RoomId { get; set; }
    }
}
