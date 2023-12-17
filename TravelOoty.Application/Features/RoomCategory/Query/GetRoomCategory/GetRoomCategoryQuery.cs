using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.RoomCategory.Query.GetRoomCategory
{
    public class GetRoomCategoryQuery : IRequest<List<RoomCategoryVM>>
    {
    }
}
