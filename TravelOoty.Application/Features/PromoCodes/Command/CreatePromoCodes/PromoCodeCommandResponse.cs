using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.HotelCategory.Commands;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.PromoCodes.Command.CreatePromoCodes
{
    public class PromoCodeCommandResponse : BaseResponse
    {
        public PromoCodeCommandResponse() : base()
        {

        }
        public PromoCodesDto PromoCodeDto { get; set; }
    
        
    }
}
