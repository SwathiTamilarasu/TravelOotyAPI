using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Rooms.Query.GetRoomByUserId
{
    public class GetRoomQueryByUser: IRequest<List<RoomVM>>
    {
        public string UserId { get; set; }

        public GetRoomQueryByUser(string userId)
        {
            UserId = userId;
        }
    }
}
