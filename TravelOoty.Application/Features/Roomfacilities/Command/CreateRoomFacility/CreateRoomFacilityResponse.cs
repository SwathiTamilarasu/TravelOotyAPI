using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.Roomfacilities.Command.CreateRoomFacility
{
    public class CreateRoomFacilityResponse:BaseResponse
    {
        public CreateRoomFacilityResponse() : base()
        {

        }
        public CreateRoomFacilityDto CreateRoomFacilityDto { get; set; }
    }
}
