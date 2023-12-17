using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Roomfacilities.Query.GetRoomFacilty
{
    public class GetRoomFacilityQuery:IRequest<List<RoomFacilityListVM>>
    {
        public string PropertyID { get; set; }
    }
}
