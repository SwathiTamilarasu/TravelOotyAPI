using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Property.Command.CreateProperty;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.Property.Command.UpdatePropertyApproval
{
    public class UpdatePropertyCommandResponse:BaseResponse
    {
        public UpdatePropertyCommandResponse() : base()
        {

        }
        public PropertyDto PropertyDto { get; set; }
    }
}
