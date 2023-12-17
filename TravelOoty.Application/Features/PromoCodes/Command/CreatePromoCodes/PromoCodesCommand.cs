using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Features.HotelCategory.Commands.CreateHotelCategory;

namespace TravelOoty.Application.Features.PromoCodes.Command.CreatePromoCodes
{
    public class PromoCodesCommand : IRequest<PromoCodeCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Discount { get; set; }
    }
}
