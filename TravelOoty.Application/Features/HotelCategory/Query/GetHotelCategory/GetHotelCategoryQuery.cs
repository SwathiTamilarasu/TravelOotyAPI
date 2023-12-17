using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.HotelCategory.Query.GetHotelCategory
{
    public class GetHotelCategoryQuery: IRequest<List<HotelCategoryVM>>
    {
    }
}
