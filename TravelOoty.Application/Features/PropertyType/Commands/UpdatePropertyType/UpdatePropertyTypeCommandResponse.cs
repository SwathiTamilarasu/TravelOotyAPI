using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.PropertyType.Commands.UpdatePropertyType
{
    public class UpdatePropertyTypeCommandResponse : BaseResponse
    {
        public UpdatePropertyTypeCommandResponse() : base()
        {

        }
        public UpdatePropertyTypeDto PropertyTypeDto { get; set; }
    }
}
