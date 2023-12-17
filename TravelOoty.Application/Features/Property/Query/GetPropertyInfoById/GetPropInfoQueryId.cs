using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Property.Query.GetProperty;

namespace TravelOoty.Application.Features.Property.Query.GetPropertyInfoById
{
    public class GetPropInfoQueryId: IRequest<PropertyListVM>
    {
        public int PropertyId { get; set; }
        public GetPropInfoQueryId(int propertyId)
        {
            PropertyId = propertyId;
        }
    }
}
