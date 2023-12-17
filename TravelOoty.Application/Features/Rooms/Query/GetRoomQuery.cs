using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Rooms.Query
{
    public class GetRoomQuery: IRequest<RoomVM>
    {
        public string RoomId { get; set; }  
        
        public GetRoomQuery(string roomId)
        {
            RoomId = roomId;
        }
    }
}
