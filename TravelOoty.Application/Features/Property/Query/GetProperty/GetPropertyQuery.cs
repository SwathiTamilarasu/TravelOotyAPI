using MediatR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Property.Query.GetProperty
{
    public class GetPropertyQuery : IRequest<List<PropertyListVM>>
    {
        public StringValues Filter { get; set; }
        public GetPropertyQuery(StringValues filter)
        {
            Filter = filter;
        }
    }
}
