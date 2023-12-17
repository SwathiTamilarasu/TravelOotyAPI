using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.City.Command.CreateCity
{
    public class CreateCityResponse: BaseResponse

    {
        public CreateCityResponse() : base()
        {

        }
        public CreateCityDto CreateCityDto { get; set; }
    }
}
