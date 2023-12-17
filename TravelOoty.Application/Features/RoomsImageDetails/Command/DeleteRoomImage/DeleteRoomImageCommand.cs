using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.RoomsImageDetails.Command.DeleteRoomImage
{
    public class DeleteRoomImageCommand: IRequest
    {
        public int Id { get; set; }
    }
}
