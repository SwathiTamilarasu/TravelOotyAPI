using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.PropertyImageDetails.Query.GetAlImagesById
{
    public class GetPropImageQuery: IRequest<List<PropertyImageVM>>
    {
        public int PropertyId { get; set; }
        public GetPropImageQuery(int propertyId)
        {
            PropertyId = propertyId;
        }
    }
}
