using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Rooms.Command.DeleteRoom
{
    public class DeleteRoomCommand: IRequest
    {
        public int RoomId { get; set; }

    }
}
