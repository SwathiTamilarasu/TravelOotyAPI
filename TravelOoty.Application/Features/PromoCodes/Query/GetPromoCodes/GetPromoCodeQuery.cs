using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.HotelCategory.Query.GetHotelCategory;

namespace TravelOoty.Application.Features.PromoCodes.Query.GetPromoCodes
{
    public class GetPromoCodeQuery: IRequest<List<PromoCodeVM>>
    {

    }
}
