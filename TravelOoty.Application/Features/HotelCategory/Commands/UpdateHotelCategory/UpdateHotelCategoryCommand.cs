using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.HotelCategory.Commands.UpdateHotelCategory
{
    public class UpdateHotelCategoryCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
