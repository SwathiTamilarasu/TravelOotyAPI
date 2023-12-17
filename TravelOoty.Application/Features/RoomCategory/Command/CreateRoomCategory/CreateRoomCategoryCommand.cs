using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.RoomCategory.Command.CreateRoomCategory
{
    public class CreateRoomCategoryCommand : IRequest<CreateRoomCategoryCommandResponse>
    {
        public int RoomCategoryId { get; set; }
        public string Name { get; set; }
    }
}
