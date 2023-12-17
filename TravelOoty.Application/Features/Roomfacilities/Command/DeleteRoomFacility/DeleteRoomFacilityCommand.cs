using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Roomfacilities.Command.DeleteRoomFacility
{
    public class DeleteRoomFacilityCommand:IRequest
    {
        public int RoomFacilityId { get; set; }
    }
}
