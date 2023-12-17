using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Roomfacilities.Command.UpdateRoomFacility
{
    public class UpdateRoomFacilityCommand:IRequest
    {
        public int RoomFacilityId { get; set; }
        public string Name { get; set; }
    }
}
