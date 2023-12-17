using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.PromoCodes.Query.GetPromoCodes;

namespace TravelOoty.Application.Features.PromoCodes.Query.GetPromoCodesByName
{
    public class GetPromoCodeByNameQuery : IRequest<string>
    {
        public string Name { get;set; }
        public GetPromoCodeByNameQuery(string name) { 
            Name = name;
        }
    }
}
