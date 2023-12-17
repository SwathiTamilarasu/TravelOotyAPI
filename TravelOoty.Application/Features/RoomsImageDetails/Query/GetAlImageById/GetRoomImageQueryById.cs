using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.RoomsImageDetails.Query.GetAlImageById
{
    public class GetRoomImageQueryById: IRequest<List<RoomImageVM>>
    {
        public int RoomId { get; set; }
        public GetRoomImageQueryById(int roomId)
        {
            RoomId = roomId;
        }
    }
}
