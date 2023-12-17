using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.PropertyType.Commands.CreatePropertyType
{
    public class CreatePropertyTypeCommandResponse: BaseResponse
    {
        public CreatePropertyTypeCommandResponse() : base()
        {

        }
        public CreatePropertyTypeDto  PropertyTypeDto { get; set; }
    }
}
