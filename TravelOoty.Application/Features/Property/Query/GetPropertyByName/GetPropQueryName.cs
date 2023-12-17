using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.Property.Query.GetProperty;

namespace TravelOoty.Application.Features.Property.Query.GetPropertyByName
{
    public class GetPropQueryName: IRequest<List<PropertyListVM>>
    {
        public string Name { get; set; }
        public GetPropQueryName(string name)
        {
            Name = name;

        }

    }
}
