using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Rooms.Query.GetAllRooms
{
    public class GetAllRoomQuery : IRequest<List<RoomVM>>
    {
    }
}
