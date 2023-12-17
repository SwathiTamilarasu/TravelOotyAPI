using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.RoomCategory.Command.DeleteRoomCategory
{
    public class DeleteRoomCategoryCommand: IRequest
    {
        public int Id { get; set; }
    }
}
