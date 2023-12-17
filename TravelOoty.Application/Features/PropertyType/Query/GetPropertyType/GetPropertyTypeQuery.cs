using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.PropertyType.Query.GetPropertyType
{
    public class GetPropertyTypeQuery:IRequest<List<PropertyTypeListVM>>
    {
    }
}
