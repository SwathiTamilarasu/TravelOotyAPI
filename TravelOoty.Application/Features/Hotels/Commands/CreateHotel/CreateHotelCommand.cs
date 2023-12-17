using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Hotels.Commands.CreateHotel
{
    public class CreateHotelCommand:IRequest<CreateHotelCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
