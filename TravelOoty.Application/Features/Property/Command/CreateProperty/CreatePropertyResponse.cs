using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.Property.Command.CreateProperty
{
    public class CreatePropertyResponse: BaseResponse
    {
        public CreatePropertyResponse() : base()
        {

        }
        public PropertyDto PropertyDto { get; set; }
    }
}
