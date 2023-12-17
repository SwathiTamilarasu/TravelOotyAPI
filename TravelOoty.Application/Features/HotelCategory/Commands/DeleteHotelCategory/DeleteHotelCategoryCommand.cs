using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.HotelCategory.Commands.DeleteHotelCategory
{
    public class DeleteHotelCategoryCommand:IRequest
    {
        public int Id { get; set; }
    }
}
