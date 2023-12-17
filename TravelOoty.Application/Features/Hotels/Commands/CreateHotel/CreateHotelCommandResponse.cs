using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.Hotels.Commands.CreateHotel
{
    public class CreateHotelCommandResponse:BaseResponse
    {
        public CreateHotelCommandResponse():base()
        {

        }
        public CreateHotelDto Hotel { get; set; }
    }
}
