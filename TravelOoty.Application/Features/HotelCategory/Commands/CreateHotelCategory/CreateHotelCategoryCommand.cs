using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.HotelCategory.Commands.CreateHotelCategory
{
    public class CreateHotelCategoryCommand : IRequest<CreateHotelCategoryCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
