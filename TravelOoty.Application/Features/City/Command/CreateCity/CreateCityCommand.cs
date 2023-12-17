using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.City.Command.CreateCity
{
    public class CreateCityCommand: IRequest<CreateCityResponse>
    {
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}
