using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.Amenities.Commands.CreateAmenities
{
    public class CreateAmenitiesCommandResponse: BaseResponse
    {
        public CreateAmenitiesCommandResponse() : base()
        {

        }
        public AmenitiesDto AmenitiesDto { get; set; }
    }
}
