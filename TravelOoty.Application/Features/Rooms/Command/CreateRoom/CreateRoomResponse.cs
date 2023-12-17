using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.Rooms.Command.CreateRoom
{
    public class CreateRoomResponse:BaseResponse
    {
        public CreateRoomResponse() : base()
        {

        }
        public RoomDto PropertyDto { get; set; }
    }
}
