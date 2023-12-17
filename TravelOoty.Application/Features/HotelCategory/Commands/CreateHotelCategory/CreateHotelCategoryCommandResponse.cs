using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Responses;

namespace TravelOoty.Application.Features.HotelCategory.Commands.CreateHotelCategory
{
    public class CreateHotelCategoryCommandResponse: BaseResponse
    {
        public CreateHotelCategoryCommandResponse() : base()
        {

        }
        public HotelCategoriesDto HotelCategoriesDto { get; set; }
    }
}
