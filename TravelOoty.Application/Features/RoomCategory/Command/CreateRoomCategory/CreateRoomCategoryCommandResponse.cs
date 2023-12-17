using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.RoomCategory.Command.CreateRoomCategory
{
    public class CreateRoomCategoryCommandResponse: BaseResponse
    {
        public CreateRoomCategoryCommandResponse() : base()
        {

        }
        public RoomCategoriesDto RoomCategoriesDto { get; set; }
    }
}
