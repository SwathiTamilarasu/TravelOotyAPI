using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelOoty.Application.Features.Amenities.Commands.CreateAmenities
{
    public class CreateAmenitiesCommand: IRequest<CreateAmenitiesCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
