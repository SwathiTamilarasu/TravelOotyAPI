using MediatR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Property.Query.GetProperty;

namespace TravelOoty.Application.Features.Property.Query.GetApprovedProp
{
    public class GetApprovedPropQuery : IRequest<List<PropertyListVM>>
    {
        public StringValues Filter { get; set; }
        public GetApprovedPropQuery(StringValues filter)
        {
            Filter = filter;
        }
    }
}
