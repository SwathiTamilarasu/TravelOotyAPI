using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Property.Command.UpdatePropertyApproval;
using TravelOoty.Application.Features.Property.Query.GetProperty;

namespace TravelOoty.Application.Features.Property.Query.GetUpdatePropertyById
{
    public class GetUpdatePropertyId: IRequest<UpdatePropertyCommand>
    {
        public int PropertyId { get; set; }
        public GetUpdatePropertyId(int propertyId)
        {
            PropertyId = propertyId;
        }

    }
}
