using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.City.Query.GetCity
{
    public class GetCityQuery: IRequest<List<CityListVM>>
    {

    }
}
