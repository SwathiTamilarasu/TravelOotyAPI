using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Property.Command.UpdatePropertyApproval;
using TravelOoty.Application.Features.Property.Query.GetProperty;

namespace TravelOoty.Application.Features.Property.Query.GetPropertyById
{
    public class GetPropQueryId: IRequest<UpdatePropertyCommand>
    {
        public int PropertyId { get; set; }
        public GetPropQueryId(int propertyId)
        {
            PropertyId = propertyId;
        }
    }
}
